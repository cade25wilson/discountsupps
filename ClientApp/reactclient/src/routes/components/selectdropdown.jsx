import React from 'react';
import { useNavigate } from 'react-router-dom';

export default function SelectDropdown() {
    const navigate = useNavigate();

    const handleChange = (event) => {
        const orderBy = event.target.value;
        navigate(`?orderby=${orderBy}`);
    };

    return (
        <div className="col-4 col-lg-2">
            <select name="orderby" className="form-select" onChange={handleChange}>
                <option value="-discount">Discount</option>
                <option value="-discount_price">Lowest Price</option>
                <option value="discount_price">Highest Price</option>
            </select>
        </div> 
    );
}