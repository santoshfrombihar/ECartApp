const prices = { q1: 18499, q2: 2499, q3: 8995 };
const origPrices = { q1: 22999, q2: 3999, q3: 10995 };
let couponApplied = 0;

function changeQty(id, delta) {
    const el = document.getElementById(id);
    let v = parseInt(el.textContent) + delta;
    if (v < 1) v = 1;
    if (v > 9) v = 9;
    el.textContent = v;
    recalc();
}

function removeItem(id) {
    const el = document.getElementById(id);
    if (el) el.style.display = 'none';
    recalc();
}

function recalc() {
    const items = ['q1', 'q2', 'q3'];
    let subtotal = 0, origTotal = 0;
    items.forEach(q => {
        const row = document.getElementById(q);
        if (!row) return;
        const itemEl = q === 'q1' ? document.getElementById('item1') || document.querySelector('.product-line') : document.getElementById('item' + q.slice(1));
        const qty = parseInt(document.getElementById(q).textContent);
        subtotal += prices[q] * qty;
        origTotal += origPrices[q] * qty;
    });
    const discount = origTotal - subtotal;
    const gst = Math.round(subtotal * 0.18);
    const total = subtotal + gst - couponApplied;
    document.getElementById('subtotal').textContent = '₹' + subtotal.toLocaleString('en-IN');
    document.getElementById('discount').textContent = '-₹' + discount.toLocaleString('en-IN');
    document.getElementById('gst').textContent = '₹' + gst.toLocaleString('en-IN');
    document.getElementById('totalAmt').textContent = '₹' + total.toLocaleString('en-IN');
    document.getElementById('savingsAmt').textContent = '₹' + (discount + couponApplied).toLocaleString('en-IN');
    if (couponApplied > 0) {
        document.getElementById('couponRow').style.display = 'flex';
        document.getElementById('couponDiscount').textContent = '-₹' + couponApplied.toLocaleString('en-IN');
    }
}

function applyCoupon() {
    const code = document.getElementById('couponInput').value.trim().toUpperCase();
    const msg = document.getElementById('couponMsg');
    msg.style.display = 'block';
    if (code === 'SAVE10') {
        couponApplied = 2595;
        msg.style.color = '#1a9e5f';
        msg.textContent = 'Coupon applied! ₹2,595 saved.';
    } else if (code === 'FIRST50') {
        couponApplied = 500;
        msg.style.color = '#1a9e5f';
        msg.textContent = 'Coupon applied! ₹500 saved on first order.';
    } else if (code === 'UPI5') {
        couponApplied = 1298;
        msg.style.color = '#1a9e5f';
        msg.textContent = 'Coupon applied! Extra 5% off with UPI.';
    } else {
        couponApplied = 0;
        msg.style.color = '#d0374a';
        msg.textContent = 'Invalid coupon code. Try SAVE10, FIRST50 or UPI5.';
    }
    recalc();
}

function selectPay(card) {
    document.querySelectorAll('.radio-card').forEach(c => c.classList.remove('selected'));
    card.classList.add('selected');
    card.querySelector('input[type=radio]').checked = true;
}

function placeOrder() {
    const btn = document.querySelector('.place-btn');
    btn.textContent = 'Placing your order...';
    btn.style.background = '#1a9e5f';
    setTimeout(() => {
        btn.innerHTML = '<i class="bi bi-check-circle-fill" style="margin-right:6px;"></i>Order placed successfully!';
    }, 1500);
}