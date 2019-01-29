/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Gets information about uploads, given an AWS Device Farm project ARN.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "DFUploadList")]
    [OutputType("Amazon.DeviceFarm.Model.Upload")]
    [AWSCmdlet("Calls the AWS Device Farm ListUploads API operation.", Operation = new[] {"ListUploads"})]
    [AWSCmdletOutput("Amazon.DeviceFarm.Model.Upload",
        "This cmdlet returns a collection of Upload objects.",
        "The service call response (type Amazon.DeviceFarm.Model.ListUploadsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetDFUploadListCmdlet : AmazonDeviceFarmClientCmdlet, IExecutor
    {
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the project for which you want to list uploads.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of upload.</para><para>Must be one of the following values:</para><ul><li><para>ANDROID_APP: An Android upload.</para></li><li><para>IOS_APP: An iOS upload.</para></li><li><para>WEB_APP: A web appliction upload.</para></li><li><para>EXTERNAL_DATA: An external data upload.</para></li><li><para>APPIUM_JAVA_JUNIT_TEST_PACKAGE: An Appium Java JUnit test package upload.</para></li><li><para>APPIUM_JAVA_TESTNG_TEST_PACKAGE: An Appium Java TestNG test package upload.</para></li><li><para>APPIUM_PYTHON_TEST_PACKAGE: An Appium Python test package upload.</para></li><li><para>APPIUM_NODE_TEST_PACKAGE: An Appium Node.js test package upload.</para></li><li><para>APPIUM_RUBY_TEST_PACKAGE: An Appium Ruby test package upload.</para></li><li><para>APPIUM_WEB_JAVA_JUNIT_TEST_PACKAGE: An Appium Java JUnit test package upload for a
        /// web app.</para></li><li><para>APPIUM_WEB_JAVA_TESTNG_TEST_PACKAGE: An Appium Java TestNG test package upload for
        /// a web app.</para></li><li><para>APPIUM_WEB_PYTHON_TEST_PACKAGE: An Appium Python test package upload for a web app.</para></li><li><para>APPIUM_WEB_NODE_TEST_PACKAGE: An Appium Node.js test package upload for a web app.</para></li><li><para>APPIUM_WEB_RUBY_TEST_PACKAGE: An Appium Ruby test package upload for a web app.</para></li><li><para>CALABASH_TEST_PACKAGE: A Calabash test package upload.</para></li><li><para>INSTRUMENTATION_TEST_PACKAGE: An instrumentation upload.</para></li><li><para>UIAUTOMATION_TEST_PACKAGE: A uiautomation test package upload.</para></li><li><para>UIAUTOMATOR_TEST_PACKAGE: A uiautomator test package upload.</para></li><li><para>XCTEST_TEST_PACKAGE: An XCode test package upload.</para></li><li><para>XCTEST_UI_TEST_PACKAGE: An XCode UI test package upload.</para></li><li><para>APPIUM_JAVA_JUNIT_TEST_SPEC: An Appium Java JUnit test spec upload.</para></li><li><para>APPIUM_JAVA_TESTNG_TEST_SPEC: An Appium Java TestNG test spec upload.</para></li><li><para>APPIUM_PYTHON_TEST_SPEC: An Appium Python test spec upload.</para></li><li><para>APPIUM_NODE_TEST_SPEC: An Appium Node.js test spec upload.</para></li><li><para> APPIUM_RUBY_TEST_SPEC: An Appium Ruby test spec upload.</para></li><li><para>APPIUM_WEB_JAVA_JUNIT_TEST_SPEC: An Appium Java JUnit test spec upload for a web app.</para></li><li><para>APPIUM_WEB_JAVA_TESTNG_TEST_SPEC: An Appium Java TestNG test spec upload for a web
        /// app.</para></li><li><para>APPIUM_WEB_PYTHON_TEST_SPEC: An Appium Python test spec upload for a web app.</para></li><li><para>APPIUM_WEB_NODE_TEST_SPEC: An Appium Node.js test spec upload for a web app.</para></li><li><para>APPIUM_WEB_RUBY_TEST_SPEC: An Appium Ruby test spec upload for a web app.</para></li><li><para>INSTRUMENTATION_TEST_SPEC: An instrumentation test spec upload.</para></li><li><para>XCTEST_UI_TEST_SPEC: An XCode UI test spec upload.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        /// <br/>In order to manually control output pagination, assign $null, for the first call, and the value of $AWSHistory.LastServiceResponse.NextToken, for subsequent calls, to this parameter.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Arn = this.Arn;
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
            System.String _nextMarker = null;
            bool _userControllingPaging = false;
            if (ParameterWasBound("NextToken"))
            {
                _nextMarker = cmdletContext.NextToken;
                _userControllingPaging = true;
            }
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.Uploads;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        if (_userControllingPaging)
                        {
                            int _receivedThisCall = response.Uploads.Count;
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                    
                } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextMarker));
            }
            finally
            {
                if (_userControllingPaging)
                {
                    WriteProgressCompleteRecord("Retrieving", "Retrieved records");
                }
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
                #if DESKTOP
                return client.ListUploads(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListUploadsAsync(request);
                return task.Result;
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
            public System.String Arn { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.DeviceFarm.UploadType Type { get; set; }
        }
        
    }
}
