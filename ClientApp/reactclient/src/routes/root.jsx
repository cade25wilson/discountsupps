import { Outlet, Link } from "react-router-dom";
import Header from "./header";
import Footer from "./footer";
import HeaderMessage from "./components/headermessage";
import SelectDropdown from "./components/selectdropdown";
import SearchForm from "./components/searchform";
import ProductLayout from "./components/productlayout";
import PaginationLayout from "./components/paginationlayout";

export default function Root() {
    return (
        <>
        <Header />
        <div className="container p-4">
            <div className="row">
                <HeaderMessage />
                <SelectDropdown />
                <SearchForm />
            </div>
            <div className="row d-flex align-items-stretch pb-5">
                <div className="col-xl-3 col-lg-4 col-12 mt-3 h-auto">
                    <ProductLayout />
                </div>
            </div>
            <PaginationLayout />
        </div>
        <Footer />
        </>
    );
}