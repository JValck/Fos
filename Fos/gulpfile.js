/// <binding BeforeBuild='default' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp'),
    fs = require('fs'),
    less = require('gulp-less'),
    cssmin = require('gulp-cssmin'),
    rename = require('gulp-rename'),
    babel = require('gulp-babel'),
    concat = require('gulp-concat'),
    pump = require('pump'),
    uglify = require('gulp-uglify'),
    browserify = require('browserify'),
    babelify = require('babelify'),
    source = require('vinyl-source-stream'),
    buffer = require('vinyl-buffer'),
    sourcemaps = require('gulp-sourcemaps'),
    sass = require('gulp-sass');

var paths = {
    "node": "./node_modules/",
    "webroot": "wwwroot/",
    "cssAssets": "Resources/Assets/css/",
    "jsAssets":"Resources/Assets/js/"
}

gulp.task('default', ['sass', 'js']);

gulp.task('sass', function () {
    gulp.src(paths.cssAssets + "app.scss")
        .pipe(sass())
        .pipe(cssmin())
        .pipe(rename({suffix: '.min'}))
        .pipe(gulp.dest(paths.webroot + "css"));

    gulp.src(paths.cssAssets + "app.scss")
        .pipe(sass())
        .pipe(gulp.dest(paths.webroot + "css"));
});

gulp.task('js', function () {
    convertJs('app.js');
    convertJs('createOrder.js');
    convertJs('pay.js');
});

function convertJs(jsFileName) {
    browserify({ entries: paths.jsAssets + jsFileName, debug: true })
        .transform("babelify", { presets: ["es2015"] })
        .bundle()
        .pipe(source(jsFileName))
        .pipe(buffer())
        .pipe(uglify())
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest(paths.webroot + "js"));

    browserify({ entries: paths.jsAssets + jsFileName, debug: true })
        .transform("babelify", { presets: ["es2015"] })
        .bundle()
        .pipe(source(jsFileName))
        .pipe(gulp.dest(paths.webroot + "js"));
}