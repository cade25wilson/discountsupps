import { Link } from 'react-router-dom';
import PropTypes from 'prop-types';
import { useEffect } from 'react';
import { useState } from 'react';

function PaginationLayout({url, totalPages}) {
    const [page, setPage] = useState(1);
    const [orderBy, setOrderBy] = useState('-discount');

    useEffect(() => {
        const urlParams = new URLSearchParams(url);
        setPage(urlParams.get('page') || 1);
        setOrderBy(urlParams.get('orderBy') || '-discount');
    }, [url, totalPages]);

    const scrollTop = () => {
        window.scrollTo({ top: 0, behavior: 'smooth' });
    }

    return (
    <div className="row">
        <div className="col-12">
            <div className="d-flex justify-content-center">
                {page > 1 && (
                <Link
                    className="btn btn-outline-primary mx-2 bottom-btn"
                    to={`${url ? `/${url}` : ''}?page=${parseInt(page) - 1}&orderBy=${orderBy}`}  
                    onClick={scrollTop}              >
                    Previous
                </Link>
                )}
                {page < totalPages && (
                <Link
                    className="btn btn-outline-primary mx-2 bottom-btn"
                    to={`${url ? `/${url}` : ''}?page=${parseInt(page) + 1}&orderBy=${orderBy}`}      
                    onClick={scrollTop}          >
                    Next
                </Link>
                )}
            </div>
        </div>
    </div>
    )   
}

PaginationLayout.propTypes = {
    url: PropTypes.string,
    totalPages: PropTypes.number.isRequired,
};

export default PaginationLayout;