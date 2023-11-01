import React, { useEffect, useState } from 'react';
import { Outlet, Link, useLocation } from "react-router-dom";
import Header from "./header";
import Footer from "./footer";
import HeaderMessage from "./components/headermessage";
import SelectDropdown from "./components/selectdropdown";
import SearchForm from "./components/searchform";
import ProductLayout from "./components/productlayout";
import PaginationLayout from "./components/paginationlayout";
import axios from "axios";

export default function Root() {
    const [data, setData] = useState(null);
    const [params, setParams] = useState({orderBy: '-discount'});
    const location = useLocation();

    useEffect(() => {
        const searchParams = new URLSearchParams(location.search);
        const newParams = Object.fromEntries(searchParams.entries());
        setParams(newParams);
    }, [location.search]);

    useEffect(() => {
        axios.get('http://localhost:5081/api/supplement', { params })
            .then(response => {
                console.log(params)
                setData(response.data);
            })
            .catch(error => {
                console.error('There was an error!', error);
            });
    }, [params]);
    // function to update parameters and trigger a new API call
    const updateParams = (newParams) => {
        setParams(prevParams => ({ ...prevParams, ...newParams }));
    };

    return (
        <>
        <Header />
        <div className="container p-4">
            {data ? (
                <>
            <div className="row">
                <HeaderMessage totalProducts={data && data.totalItems} />
                <SelectDropdown />
                <SearchForm onSearch={updateParams} /> 
            </div>
            <div className="row d-flex align-items-stretch pb-5">
                {data.items.map((item, index) => (
                    <div className="col-xl-3 col-lg-4 col-12 mt-3 h-auto" key={index}>
                        <ProductLayout product={item} /> 
                    </div>
                )
                )}
            </div>
            {data && <PaginationLayout totalPages={data.totalPages} />}
            </>
            ) : (
                <div>Loading...</div>
            )}
        </div>
        <Footer />
        </>
    );
}