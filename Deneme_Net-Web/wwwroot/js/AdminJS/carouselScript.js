
document.querySelectorAll('.image-carousel').forEach(carousel => {
const track = carousel.querySelector('.image-track');
const prevBtn = carousel.querySelector('.prev-btn');
const nextBtn = carousel.querySelector('.next-btn');

prevBtn.addEventListener('click', () => {
    track.scrollBy({ left: -100, behavior: 'smooth' });
});

nextBtn.addEventListener('click', () => {
    track.scrollBy({ left: 100, behavior: 'smooth' });
});
});

