alert("DONE")
<script>
  function saveData(event) {
    event.preventDefault();
    localStorage.setItem("name", document.getElementById("name").value);
    localStorage.setItem("email", document.getElementById("email").value);
    window.location.href = "profile.html";
  }

  function saveCounselorData(event) {
    event.preventDefault();
    const data = {
      name: document.getElementById("name").value,
      email: document.getElementById("email").value,
      nic: document.getElementById("nic").value,
      contact: document.getElementById("contact").value,
      designation: document.getElementById("designation").value,
      department: document.getElementById("department").value
    };
    localStorage.setItem("counselorData", JSON.stringify(data));
    window.location.href = "counselor-profile.html";
  }

function viewFeedback() {
    const id = document.getElementById("university-id").value;
    const date = document.getElementById("date").value;
    const feedback = document.getElementById("feedback").value;
    const experience = document.querySelector('input[name="experience"]:checked').value;

    alert(`Feedback Summary:\n\nUniversity ID: ${id}\nDate: ${date}\nFeedback: ${feedback}\nExperience: ${experience}`);
  }  
</script>
