// JavaScript Document

 $(document).ready(function() { 
  var length,            //  图片的个数
   currentIndex = 0, 
   interval,             //  定时器的id
   hasStarted = false, //是否已经开始轮播 
   t = 5000; //轮播时间间隔 
  length = $('.slider-panel').length; 
  //将除了第一张图片的隐藏 
  $('.slider-panel:not(:first)').hide();

  //将第一个slider-item设为激活状态 ，其他的正常显示
  $('.slider-item:first').addClass('slider-item-selected');

  //隐藏向前、向后翻按钮 
  //$('.slider-page').hide(); 
  //鼠标上悬时显示向前、向后翻按钮,停止滑动，鼠标离开时隐藏向前、向后翻按钮，开始滑动 
  $('.slider-panel, .slider-pre, .slider-next').hover(function() { 
   stop();      
   //$('.slider-page').show(); 
  },
  function() { 
   //$('.slider-page').hide(); 
   start(); 
  });



  //$(".slider-item").click(function (e) {
  //    alert("aaa");
  // stop(); 
  // var preIndex = $(".slider-item").filter(".slider-item-selected").index(); 
  // currentIndex = $(this).index(); 
  // play(preIndex, currentIndex); 
  //}
  //, function () {
  // start(); 
  //});
  


  $(".slider-item").click(function (e) {      
      stop();
      var preIndex = $(".slider-item").filter(".slider-item-selected").index();
      currentIndex = $(this).index();
      play(preIndex, currentIndex);
  });

  $(".slider-item").mouseleave(function () {
      start();
  })


  $('.slider-pre').unbind('click'); 
  $('.slider-pre').bind('click', function() { 
   pre(); //点击左边的箭头，调用pre()函数
  });

  $('.slider-next').unbind('click'); 
  $('.slider-next').bind('click', function() { 
   next(); //点击右边的箭头，调用next()函数
  });

  /* 
   	向前翻页 
   */
  function pre() { 
   var preIndex = currentIndex; 
   currentIndex = (--currentIndex + length) % length;      //  防止出现负值
   play(preIndex, currentIndex); 
  }

  /** 
   * 向后翻页 
   */
  function next() { 
   var preIndex = currentIndex; 
   currentIndex = ++currentIndex % length; 
   play(preIndex, currentIndex); 
  }

  /** 
   * 从preIndex页翻到currentIndex页 
   * preIndex 整数，翻页的起始页 
   * currentIndex 整数，翻到的那页 
   */
  function play(preIndex, currentIndex) {
   $('.slider-panel').each(function (index) {
       if (index != currentIndex) {
           $('.slider-panel').eq(index).fadeOut(500);
       }
       else {
           $('.slider-panel').eq(index).fadeIn(1000);
       }
   })

   $('.slider-item').removeClass('slider-item-selected'); 
   $('.slider-item').eq(currentIndex).addClass('slider-item-selected'); 
  }

  /** 
   * 开始轮播 
   */
  function start() { 
       if(!hasStarted) { 
        hasStarted = true; 
        interval = setInterval(next, t); 
       } 
  }


  /** 
   * 停止轮播 
   */
  function stop() { 
   clearInterval(interval); 
   hasStarted = false; 
  }

  //加载时默认轮播 
  start(); 
 }); 