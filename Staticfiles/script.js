// Button click event
const welcomeButton = document.getElementById("welcomeButton");

welcomeButton.addEventListener("click", function () {
    const message = document.getElementById("message");
    message.textContent = "Hello! Welcome to my website.";
});

// Form submit event
const contactForm = document.getElementById("contactForm");

contactForm.addEventListener("submit", function (event) {
    event.preventDefault();

    const name = document.getElementById("name").value;
    const email = document.getElementById("email").value;
    const formMessage = document.getElementById("formMessage");

    formMessage.textContent =
        `Thank you ${name}! Your email is ${email}.`;
});
