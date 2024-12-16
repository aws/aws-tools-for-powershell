/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    [AWSCmdlet("Calls the AWS Device Farm CreateUpload API operation.", Operation = new[] {"CreateUpload"}, SelectReturnType = typeof(Amazon.DeviceFarm.Model.CreateUploadResponse))]
    [AWSCmdletOutput("Amazon.DeviceFarm.Model.Upload or Amazon.DeviceFarm.Model.CreateUploadResponse",
        "This cmdlet returns an Amazon.DeviceFarm.Model.Upload object.",
        "The service call response (type Amazon.DeviceFarm.Model.CreateUploadResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewDFUploadCmdlet : AmazonDeviceFarmClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ContentType
        /// <summary>
        /// <para>
        /// <para>The upload's content type (for example, <c>application/octet-stream</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        public System.String ContentType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The upload's file name. The name should not contain any forward slashes (<c>/</c>).
        /// If you are uploading an iOS app, the file name must end with the <c>.ipa</c> extension.
        /// If you are uploading an Android app, the file name must end with the <c>.apk</c> extension.
        /// For all others, the file name must end with the <c>.zip</c> file extension.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ProjectArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the project for the upload.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ProjectArn { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The upload's upload type.</para><para>Must be one of the following values:</para><ul><li><para>ANDROID_APP</para></li><li><para>IOS_APP</para></li><li><para>WEB_APP</para></li><li><para>EXTERNAL_DATA</para></li><li><para>APPIUM_JAVA_JUNIT_TEST_PACKAGE</para></li><li><para>APPIUM_JAVA_TESTNG_TEST_PACKAGE</para></li><li><para>APPIUM_PYTHON_TEST_PACKAGE</para></li><li><para>APPIUM_NODE_TEST_PACKAGE</para></li><li><para>APPIUM_RUBY_TEST_PACKAGE</para></li><li><para>APPIUM_WEB_JAVA_JUNIT_TEST_PACKAGE</para></li><li><para>APPIUM_WEB_JAVA_TESTNG_TEST_PACKAGE</para></li><li><para>APPIUM_WEB_PYTHON_TEST_PACKAGE</para></li><li><para>APPIUM_WEB_NODE_TEST_PACKAGE</para></li><li><para>APPIUM_WEB_RUBY_TEST_PACKAGE</para></li><li><para>INSTRUMENTATION_TEST_PACKAGE</para></li><li><para>XCTEST_TEST_PACKAGE</para></li><li><para>XCTEST_UI_TEST_PACKAGE</para></li><li><para>APPIUM_JAVA_JUNIT_TEST_SPEC</para></li><li><para>APPIUM_JAVA_TESTNG_TEST_SPEC</para></li><li><para>APPIUM_PYTHON_TEST_SPEC</para></li><li><para>APPIUM_NODE_TEST_SPEC</para></li><li><para>APPIUM_RUBY_TEST_SPEC</para></li><li><para>APPIUM_WEB_JAVA_JUNIT_TEST_SPEC</para></li><li><para>APPIUM_WEB_JAVA_TESTNG_TEST_SPEC</para></li><li><para>APPIUM_WEB_PYTHON_TEST_SPEC</para></li><li><para>APPIUM_WEB_NODE_TEST_SPEC</para></li><li><para>APPIUM_WEB_RUBY_TEST_SPEC</para></li><li><para>INSTRUMENTATION_TEST_SPEC</para></li><li><para>XCTEST_UI_TEST_SPEC</para></li></ul><para> If you call <c>CreateUpload</c> with <c>WEB_APP</c> specified, AWS Device Farm throws
        /// an <c>ArgumentException</c> error.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DeviceFarm.UploadType")]
        public Amazon.DeviceFarm.UploadType Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Upload'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DeviceFarm.Model.CreateUploadResponse).
        /// Specifying the name of a property of type Amazon.DeviceFarm.Model.CreateUploadResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Upload";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DFUpload (CreateUpload)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DeviceFarm.Model.CreateUploadResponse, NewDFUploadCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ContentType = this.ContentType;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProjectArn = this.ProjectArn;
            #if MODULAR
            if (this.ProjectArn == null && ParameterWasBound(nameof(this.ProjectArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
            try
            {
                #if DESKTOP
                return client.CreateUpload(request);
                #elif CORECLR
                return client.CreateUploadAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String ContentType { get; set; }
            public System.String Name { get; set; }
            public System.String ProjectArn { get; set; }
            public Amazon.DeviceFarm.UploadType Type { get; set; }
            public System.Func<Amazon.DeviceFarm.Model.CreateUploadResponse, NewDFUploadCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Upload;
        }
        
    }
}
