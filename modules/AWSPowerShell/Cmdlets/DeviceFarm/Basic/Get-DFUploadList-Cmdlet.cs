/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.DeviceFarm;
using Amazon.DeviceFarm.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DF
{
    /// <summary>
    /// Gets information about uploads, given an AWS Device Farm project ARN.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "DFUploadList")]
    [OutputType("Amazon.DeviceFarm.Model.Upload")]
    [AWSCmdlet("Calls the AWS Device Farm ListUploads API operation.", Operation = new[] {"ListUploads"}, SelectReturnType = typeof(Amazon.DeviceFarm.Model.ListUploadsResponse))]
    [AWSCmdletOutput("Amazon.DeviceFarm.Model.Upload or Amazon.DeviceFarm.Model.ListUploadsResponse",
        "This cmdlet returns a collection of Amazon.DeviceFarm.Model.Upload objects.",
        "The service call response (type Amazon.DeviceFarm.Model.ListUploadsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetDFUploadListCmdlet : AmazonDeviceFarmClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the project for which you want to list uploads.</para>
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
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of upload.</para><para>Must be one of the following values:</para><ul><li><para>ANDROID_APP</para></li><li><para>IOS_APP</para></li><li><para>WEB_APP</para></li><li><para>EXTERNAL_DATA</para></li><li><para>APPIUM_JAVA_JUNIT_TEST_PACKAGE</para></li><li><para>APPIUM_JAVA_TESTNG_TEST_PACKAGE</para></li><li><para>APPIUM_PYTHON_TEST_PACKAGE</para></li><li><para>APPIUM_NODE_TEST_PACKAGE</para></li><li><para>APPIUM_RUBY_TEST_PACKAGE</para></li><li><para>APPIUM_WEB_JAVA_JUNIT_TEST_PACKAGE</para></li><li><para>APPIUM_WEB_JAVA_TESTNG_TEST_PACKAGE</para></li><li><para>APPIUM_WEB_PYTHON_TEST_PACKAGE</para></li><li><para>APPIUM_WEB_NODE_TEST_PACKAGE</para></li><li><para>APPIUM_WEB_RUBY_TEST_PACKAGE</para></li><li><para>INSTRUMENTATION_TEST_PACKAGE</para></li><li><para>XCTEST_TEST_PACKAGE</para></li><li><para>XCTEST_UI_TEST_PACKAGE</para></li><li><para>APPIUM_JAVA_JUNIT_TEST_SPEC</para></li><li><para>APPIUM_JAVA_TESTNG_TEST_SPEC</para></li><li><para>APPIUM_PYTHON_TEST_SPEC</para></li><li><para>APPIUM_NODE_TEST_SPEC</para></li><li><para> APPIUM_RUBY_TEST_SPEC</para></li><li><para>APPIUM_WEB_JAVA_JUNIT_TEST_SPEC</para></li><li><para>APPIUM_WEB_JAVA_TESTNG_TEST_SPEC</para></li><li><para>APPIUM_WEB_PYTHON_TEST_SPEC</para></li><li><para>APPIUM_WEB_NODE_TEST_SPEC</para></li><li><para>APPIUM_WEB_RUBY_TEST_SPEC</para></li><li><para>INSTRUMENTATION_TEST_SPEC</para></li><li><para>XCTEST_UI_TEST_SPEC</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DeviceFarm.UploadType")]
        public Amazon.DeviceFarm.UploadType Type { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>An identifier that was returned from the previous call to this operation, which can
        /// be used to return the next set of items in the list.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Uploads'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DeviceFarm.Model.ListUploadsResponse).
        /// Specifying the name of a property of type Amazon.DeviceFarm.Model.ListUploadsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Uploads";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DeviceFarm.Model.ListUploadsResponse, GetDFUploadListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NextToken = this.NextToken;
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.DeviceFarm.Model.ListUploadsRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.DeviceFarm.Model.ListUploadsResponse CallAWSServiceOperation(IAmazonDeviceFarm client, Amazon.DeviceFarm.Model.ListUploadsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Device Farm", "ListUploads");
            try
            {
                return client.ListUploadsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Arn { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.DeviceFarm.UploadType Type { get; set; }
            public System.Func<Amazon.DeviceFarm.Model.ListUploadsResponse, GetDFUploadListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Uploads;
        }
        
    }
}
