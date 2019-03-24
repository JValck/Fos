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

gulp.task('sass', function () {
    return gulp.src(paths.cssAssets + "app.scss")
        .pipe(sass())
        .pipe(cssmin())
        .pipe(rename({suffix: '.min'}))
        .pipe(gulp.dest(paths.webroot + "css"));
}, (done) => done());

gulp.task('css', function () {
    return gulp.src(paths.cssAssets + "app.scss")
        .pipe(sass())
        .pipe(gulp.dest(paths.webroot + "css"));
}, (done) => done());

gulp.task('js', function () {
    convertSpecialJs('app.js', false);
    convertJs('createOrder.js', false);
    return convertJs('pay.js', false);
}, (done) => done());

gulp.task('jsdev', function () {
    convertSpecialJs('app.js', true);
    convertJs('createOrder.js', true);
    return convertJs('pay.js', true);
}, (done) => done());

function convertJs(jsFileName, dev) {  
    if (dev) {
        return gulp.src(paths.jsAssets + jsFileName)
            .pipe(gulp.dest(paths.webroot + "js"));
    } else {
        return browserify({ entries: paths.jsAssets + jsFileName, debug: true })
            .transform("babelify", { presets: ["@babel/preset-env"] })
            .bundle()
            .pipe(source(jsFileName))
            .pipe(buffer())
            .pipe(uglify())
            .pipe(rename({ suffix: '.min' }))
            .pipe(gulp.dest(paths.webroot + "js"));
    }
}

function convertSpecialJs(jsFileName, dev) {
    convertJs(jsFileName, dev);

    return browserify({ entries: paths.jsAssets + jsFileName, debug: true })
        .transform("babelify", { presets: ["@babel/preset-env"] })
        .bundle()
        .pipe(source(jsFileName))
        .pipe(gulp.dest(paths.webroot + "js"));    
}

gulp.task('default', gulp.parallel('css', 'sass', 'jsdev', 'js'), (done) => done());