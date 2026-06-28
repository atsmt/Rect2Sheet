FeatureScript 2837;
import(path : "onshape/std/geometry.fs", version : "2837.0");
import(path : "onshape/std/sheetMetalStart.fs", version : "2837.0");
import(path : "onshape/std/sheetMetalFlange.fs", version : "2837.0");
import(path : "onshape/std/sheetMetalTab.fs", version : "2837.0");
annotation { "Feature Type Name" : "hgen-sm-part-sm" }
export const smPart = defineFeature(function(context is Context, id is Id, definition is map)
    precondition { }
    {
        const thickness = 1.0 * millimeter;
        const bendRadius = 1.0 * millimeter;

        // === Root Tab 0 ===
        var sketch0 = newSketchOnPlane(context, id + "sketch0", { "sketchPlane" : plane(vector(0.0, 0.0, 0.0) * millimeter, vector(0.0, 0.0, 1.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(389.000000, 0.000000) * millimeter, vector(389.000000, 147.000000) * millimeter, vector(379.000000, 147.000000) * millimeter, vector(278.676500, 200.000000) * millimeter, vector(278.676500, 210.000000) * millimeter, vector(100.323500, 210.000000) * millimeter, vector(100.323500, 200.000000) * millimeter, vector(0.000000, 147.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(193.377529, 96.074358, 0.000000) * millimeter),
            "excludeFillets" : false
        });
        sheetMetalStart(context, id + "smStart0", {
            "process" : SMProcessType.CONVERT,
            "partToConvert" : qCreatedBy(id + "surf0", EntityType.BODY),
            "bends" : qNothing(),
            "facesToExclude" : qNothing(),
            "thickness" : thickness,
            "radius" : bendRadius
        });

        // === Child Tab 1 from 0 (one_bend) ===
        // Flange 0->1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(189.500000, 210.000000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 90.000000 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 1
        var sketchRem1 = newSketchOnPlane(context, id + "sketchRem1", { "sketchPlane" : plane(vector(379.0, 210.0, 105.0) * millimeter, vector(0.0, 1.0, 0.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1, "polyRem1", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(100.323500, -95.000000) * millimeter, vector(100.323500, -103.000000) * millimeter, vector(278.676500, -103.000000) * millimeter, vector(278.676500, -95.000000) * millimeter, vector(379.000000, 0.000000) * millimeter, vector(379.000000, 252.000000) * millimeter, vector(0.000000, 252.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1);
        sheetMetalTab(context, id + "smTab1", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1"), vector(189.500000, 210.000000, 5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_1", EntityType.FACE), vector(189.500000, 210.000000, 5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 3 from 0 (two_bend) ===
        // Flange 0->1_0_3: bend=59.16deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_0_3a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(389.000000, 73.500000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 59.164672 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 1_0_3
        var wallFace1_0_3a = qClosestTo(qCreatedBy(id + "flange0_1_0_3a", EntityType.FACE), vector(386.437138, 73.500000, 4.293220) * millimeter);
        var faceN1_0_3a = evPlane(context, { "face" : wallFace1_0_3a }).normal;
        var skN1_0_3a = dot(faceN1_0_3a, vector(0.8586440122, 0.0, 0.5125723951)) >= 0 ? faceN1_0_3a : -faceN1_0_3a;
        var sketchRem1_0_3a = newSketchOnPlane(context, id + "sketchRem1_0_3a", { "sketchPlane" : plane(vector(383.8743, 0.0, 8.5864) * millimeter, skN1_0_3a, vector(0.5125723951, 0.0, -0.8586440122)) });
        skPolyline(sketchRem1_0_3a, "polyRem1_0_3a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(7.999953, 0.000000) * millimeter, vector(7.999953, 147.000000) * millimeter, vector(0.000000, 147.000000) * millimeter, vector(-592.594576, 189.000000) * millimeter, vector(-600.594529, 189.000000) * millimeter, vector(-600.594529, -190.000000) * millimeter, vector(-592.594576, -190.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_0_3a);
        sheetMetalTab(context, id + "smTab1_0_3a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0_3a"), vector(386.437138, 0.000000, 4.293220) * millimeter),
            "booleanUnionScope" : wallFace1_0_3a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_0_3->3: bend=120.84deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_0_3_3b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(75.000000, -0.500000, 526.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 120.835328 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 3
        var wallFace3b = qClosestTo(qCreatedBy(id + "flange1_0_3_3b", EntityType.FACE), vector(80.000000, -0.500000, 526.000000) * millimeter);
        var faceN3b = evPlane(context, { "face" : wallFace3b }).normal;
        var skN3b = dot(faceN3b, vector(0.0, 0.0, -1.0)) >= 0 ? faceN3b : -faceN3b;
        var sketchRem3b = newSketchOnPlane(context, id + "sketchRem3b", { "sketchPlane" : plane(vector(85.0, 189.0, 526.0) * millimeter, skN3b, vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem3b, "polyRem3b", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(34.758600, -32.000000) * millimeter, vector(32.758600, -42.000000) * millimeter, vector(215.241400, -42.000000) * millimeter, vector(217.241400, -32.000000) * millimeter, vector(252.000000, 0.000000) * millimeter, vector(252.000000, 379.000000) * millimeter, vector(-8.000000, 379.000000) * millimeter, vector(-8.000000, 0.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem3b);
        sheetMetalTab(context, id + "smTab3b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3b"), vector(80.000000, 189.000000, 526.000000) * millimeter),
            "booleanUnionScope" : wallFace3b,
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2 from 3 (one_bend) ===
        // Flange 3->2: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange3_2", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(211.000000, 231.000000, 526.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 90.000000 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 2
        var sketchRem2 = newSketchOnPlane(context, id + "sketchRem2", { "sketchPlane" : plane(vector(337.0, 231.0, 42.0) * millimeter, vector(0.0, -1.0, 0.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem2, "polyRem2", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(-252.000000, 0.000000) * millimeter, vector(-252.000000, 379.000000) * millimeter, vector(-217.241400, 474.000000) * millimeter, vector(-217.241400, 482.000000) * millimeter, vector(-34.758600, 482.000000) * millimeter, vector(-34.758600, 474.000000) * millimeter, vector(0.000000, 379.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2);
        sheetMetalTab(context, id + "smTab2", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2"), vector(211.000000, 231.000000, 521.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange3_2", EntityType.FACE), vector(211.000000, 231.000000, 521.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });