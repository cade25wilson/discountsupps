import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

export default function SearchForm() {
    const [search, setSearch] = useState('');
    const navigate = useNavigate();

    const handleSearch = (event) => {
        event.preventDefault();
        navigate(`/search?search=${search}`);
    };

    const handleKeyPress = (event) => {
        if (event.key === 'Enter' && search !== '') {
            handleSearch(event);
        }
    }

    return (
        <div className="col-4 col-lg-4 text-right">
            <div className="input-group mb-3">
                <input 
                    type="text" 
                    className="form-control" 
                    placeholder="Search" 
                    name="search"
                    value={search}
                    onChange={e => setSearch(e.target.value)}
                    onKeyPress={handleKeyPress}
                />
                <button className="btn btn-primary" id="button-addon2" onClick={handleSearch} disabled={search === ''}>Search</button>
            </div>
        </div>
    );
}