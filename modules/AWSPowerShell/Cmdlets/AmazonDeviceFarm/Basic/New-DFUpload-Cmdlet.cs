/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.DeviceFarm;
using Amazon.DeviceFarm.Model;

namespace Amazon.PowerShell.Cmdlets.DF
{
    /// <summary>
    /// Uploads an app or test scripts.
    /// </summary>
    [Cmdlet("New", "DFUpload", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DeviceFarm.Model.Upload")]
    [AWSCmdlet("Invokes the CreateUpload operation against AWS Device Farm.", Operation = new[] {"CreateUpload"})]
    [AWSCmdletOutput("Amazon.DeviceFarm.Model.Upload",
        "This cmdlet returns a Upload object.",
        "The service call response (type Amazon.DeviceFarm.Model.CreateUploadResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDFUploadCmdlet : AmazonDeviceFarmClientCmdlet, IExecutor
    {
        
        #region Parameter ContentType
        /// <summary>
        /// <para>
        /// <para>The upload's content type (for example, "application/octet-stream").</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public System.String ContentType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The upload's file name. The name should not contain the '/' character. If uploading
        /// an iOS app, the file name needs to end with the <code>.ipa</code> extension. If uploading
        /// an Android app, the file name needs to end with the <code>.apk</code> extension. For
        /// all others, the file name must end with the <code>.zip</code> file extension.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ProjectArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the project for the upload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String ProjectArn { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The upload's upload type.</para><para>Must be one of the following values:</para><ul><li><para>ANDROID_APP: An Android upload.</para></li><li><para>IOS_APP: An iOS upload.</para></li><li><para>WEB_APP: A web appliction upload.</para></li><li><para>EXTERNAL_DATA: An external data upload.</para></li><li><para>APPIUM_JAVA_JUNIT_TEST_PACKAGE: An Appium Java JUnit test package upload.</para></li><li><para>APPIUM_JAVA_TESTNG_TEST_PACKAGE: An Appium Java TestNG test package upload.</para></li><li><para>APPIUM_PYTHON_TEST_PACKAGE: An Appium Python test package upload.</para></li><li><para>APPIUM_WEB_JAVA_JUNIT_TEST_PACKAGE: An Appium Java JUnit test package upload.</para></li><li><para>APPIUM_WEB_JAVA_TESTNG_TEST_PACKAGE: An Appium Java TestNG test package upload.</para></li><li><para>APPIUM_WEB_PYTHON_TEST_PACKAGE: An Appium Python test package upload.</para></li><li><para>CALABASH_TEST_PACKAGE: A Calabash test package upload.</para></li><li><para>INSTRUMENTATION_TEST_PACKAGE: An instrumentation upload.</para></li><li><para>UIAUTOMATION_TEST_PACKAGE: A uiautomation test package upload.</para></li><li><para>UIAUTOMATOR_TEST_PACKAGE: A uiautomator test package upload.</para></li><li><para>XCTEST_TEST_PACKAGE: An XCode test package upload.</para></li><li><para>XCTEST_UI_TEST_PACKAGE: An XCode UI test package upload.</para></li></ul><para><b>Note</b> If you call <code>CreateUpload</code> with <code>WEB_APP</code> specified,
        /// AWS Device Farm throws an <code>ArgumentException</code> error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        [AWSConstantClassSource("Amazon.DeviceFarm.UploadType")]
        public Amazon.DeviceFarm.UploadType Type { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DFUpload (CreateUpload)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ContentType = this.ContentType;
            context.Name = this.Name;
            context.ProjectArn = this.ProjectArn;
            context.Type = this.Type;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.DeviceFarm.Model.CreateUploadRequest();
            
            if (cmdletContext.ContentType != null)
            {
                request.ContentType = cmdletContext.ContentType;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ProjectArn != null)
            {
                request.ProjectArn = cmdletContext.ProjectArn;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Upload;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.DeviceFarm.Model.CreateUploadResponse CallAWSServiceOperation(IAmazonDeviceFarm client, Amazon.DeviceFarm.Model.CreateUploadRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Device Farm", "CreateUpload");
            #if DESKTOP
            return client.CreateUpload(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateUploadAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ContentType { get; set; }
            public System.String Name { get; set; }
            public System.String ProjectArn { get; set; }
            public Amazon.DeviceFarm.UploadType Type { get; set; }
        }
        
    }
}
