<script>
// import axios from 'axios'

// export default {

// };
</script>

<template>
  <div class="container p-4">
    <div class="row">
      <div class="col col-lg-6 col-4">
        <p class="mb-0">Total results</p>
      </div>
      <div class="col-4 col-lg-2">
        <select name="orderby" class="form-select" aria-label="Sort Products By">
          <option value="-discount">Highest Discount</option>
          <option value="discount_price">Lowest Price</option>
          <option value="-discount_price">Highest Price</option>
        </select>
      </div>
      <div class="col-4 col-lg-4 text-right">
        <form class="w-100" action="" method="GET">
          <div class="input-group mb-3">
            <input type="text" class="form-control" placeholder="Search" name="search" value="">
            <button class="btn btn-primary" type="submit" id="button-addon2">Search</button>
          </div>
        </form>
      </div>
    </div>
    <div class="row d-flex align-items-stretch pb-5">
      <div class="col-xl-3 col-lg-4 col-12 mt-3 h-auto">
        <div class="border rounded p-3 h-100">
          <div class="mb-2 text-center">
            <a href="/">
              <img src="/" alt="image" class="img-thumbnail border-0">
            </a>
          </div>
          <div class="product-name h-auto">
            <h5>Test</h5>
            <div class="row h-auto">
              <div class="col-3">
                <div class="product-price">
                  <p>
                    <!-- Add discount here 
                      <span class="text-danger"><del>$1.00</del></span>
                       -->
                       $.50
                  </p>
                </div>
              </div>
              <div class="col-9">
                <div class="product-brand text-end">
                  <a href="/" class="text-black">
                    <p class="mb-0">test brand</p>
                  </a>
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-3">
                <p>$1.00</p>
              </div>
              <div class="col-9 text-end">
                <a href="/" class="text-black">
                  <p>Test Advertiser</p>
                </a>
              </div>
            </div>
            <div class="row">
              <div class="text-center">
                <a href="/" class="btn btn-primary w-75">View Product</a>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <div class="d-flex justify-content-center">
          
        </div>
      </div>
    </div>
  </div>
</template>
