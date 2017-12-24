/// <binding BeforeBuild='sass' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp'),
    fs = require('fs'),
    less = require('gulp-less'),
    cssmin = require('gulp-cssmin'),
    rename = require('gulp-rename'),
    sass = require('gulp-sass');

var paths = {
    "node": "./node_modules/",
    "webroot": "wwwroot/",
    "cssAssets": "Resources/Assets/css/"
}

gulp.task('default', function () {
    
});

gulp.task('sass', function () {
    gulp.src(paths.cssAssets + "app.scss")
        .pipe(sass())
        .pipe(cssmin())
        .pipe(gulp.dest(paths.webroot + "css"));
});