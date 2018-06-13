<template>
    <div id="uploadbox">
        <input type="file"
          id="fileinput" 
          class="file-input" 
          v-on:change="onInputChange"
          name="file">

        <div id="box">
          <span id="message">{{message}}</span>

          <div id="zone" class="drop-zone" v-on:click="clickHandler" v-on:drop="dropHandler" v-on:dragover="dragOverHandler">
              <div class="drop-zone-text">
                  <div class="file-name-input">
                      {{ fileName }}
                  </div>
                  <md-icon>cloud_upload</md-icon>
                  <div class="file-input-label">
                      Drag your file or click to browse
                  </div>
              </div>
          </div>

          <md-button id="generatebutton" class="md-raised md-primary" @click="verifyFile">Verify Certificate</md-button>
          
        </div>
    </div>
</template>

<script>
import * as apiService from "../services/apiService";

export default {
  data() {
    return {
      fileName: "",
      message: ""
    };
  },
  methods: {
    onInputChange(e) {
      var input = document.getElementById("fileinput");
      if (input) {
        if (input.files.length === 1) {
          if (this.onDropFileCallback) {
            this.onDropFileCallback(input.files.item(0));
          }
          this.fileName = input.files.item(0).name;
        }
      }
    },
    reset() {
      document.getElementById("fileinput").value = "";
      this.fileName = "";
    },
    clickHandler() {
      document.getElementById("fileinput").click();
    },
    dragOverHandler(e) {
      e.preventDefault();
    },
    dropHandler(e) {
      e.preventDefault();
      if (e.dataTransfer.files.length === 1) {
        document.getElementById("fileinput").files = e.dataTransfer.files;
        this.fileName = e.dataTransfer.files.item(0).name;
        if (this.onDropFileCallback) {
          this.onDropFileCallback(e.dataTransfer.files.item(0));
        }
      }
    },
    verifyFile() {
      var input = document.getElementById("fileinput");
      apiService
        .verifyCertificate(input.files.item(0))
        .then(
          body =>
            (this.message = body.data
              ? "Success! Valid Certificate."
              : "Failure.. Invalid Certificate.")
        );
    }
  }
};
</script>


<style lang="scss" scoped>
.drop-zone {
  width: 100%;
  height: 260px;
  text-align: center;
  background-color: #f2f2f2;
  border: 1px solid black;
  cursor: pointer;

  &:hover {
    background-color: #fff;
    border: 1px solid #000;
  }
  .drop-zone-text {
    top: 95px;
    position: relative;
    height: 20px;
    width: 100%;

    .file-name-input {
      height: 20px;
    }
    .fas {
      display: inline-block;
      margin-right: 10px;
    }
    .file-input-label {
      display: inline-block;
    }
  }
}
.file-input {
  display: none;
}
#uploadbox {
  display: flex;
  height: 100%;
}
#box {
  width: 50%;
  margin: 0 auto;
  align-self: center;
}
#zone {
  margin-top: 10px;
}
#generatebutton {
  margin-top: 10px;
  background-color: #448aff;
  color: white;
}
#message {
  font-size: 1.5em;
  font-weight: 500;
}
</style>