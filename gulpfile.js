﻿/// <binding AfterBuild='default' Clean='clean' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var del = require('rimraf');

var nodeRoot = './node_modules/';
var targetPath = './wwwroot/lib/';

gulp.task('clean', function () {
    return del([targetPath + '/**/*']);
});

gulp.task('default', function (done) {
    gulp.src(nodeRoot + "bootstrap/dist/js/bootstrap.min.js").pipe(gulp.dest(targetPath + "/bootstrap/dist/js"));
    gulp.src(nodeRoot + "bootstrap/dist/css/bootstrap.min.css").pipe(gulp.dest(targetPath + "/bootstrap/dist/css"));
    gulp.src(nodeRoot + "bootstrap/dist/fonts/*").pipe(gulp.dest(targetPath + "/bootstrap/dist/fonts"));

    gulp.src(nodeRoot + "jquery/dist/jquery.js").pipe(gulp.dest(targetPath + "/jquery/dist"));
    gulp.src(nodeRoot + "jquery/dist/jquery.min.js").pipe(gulp.dest(targetPath + "/jquery/dist"));
    gulp.src(nodeRoot + "jquery/dist/jquery.min.map").pipe(gulp.dest(targetPath + "/jquery/dist"));

    gulp.src(nodeRoot + "jquery-validation/dist/validation.min.js").pipe(gulp.dest(targetPath + "/jquery-validation/dist"));

    gulp.src(nodeRoot + "jquery-validation-unobtrusive/dist/validation.unobtrusive.min.js").pipe(gulp.dest(targetPath + "/jquery-validation-unobtrusive"));
    done();
});