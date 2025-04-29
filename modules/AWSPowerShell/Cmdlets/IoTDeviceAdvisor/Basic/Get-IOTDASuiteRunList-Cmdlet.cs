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
using Amazon.IoTDeviceAdvisor;
using Amazon.IoTDeviceAdvisor.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOTDA
{
    /// <summary>
    /// Lists runs of the specified Device Advisor test suite. You can list all runs of the
    /// test suite, or the runs of a specific version of the test suite.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">ListSuiteRuns</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "IOTDASuiteRunList")]
    [OutputType("Amazon.IoTDeviceAdvisor.Model.SuiteRunInformation")]
    [AWSCmdlet("Calls the AWS IoT Core Device Advisor ListSuiteRuns API operation.", Operation = new[] {"ListSuiteRuns"}, SelectReturnType = typeof(Amazon.IoTDeviceAdvisor.Model.ListSuiteRunsResponse))]
    [AWSCmdletOutput("Amazon.IoTDeviceAdvisor.Model.SuiteRunInformation or Amazon.IoTDeviceAdvisor.Model.ListSuiteRunsResponse",
        "This cmdlet returns a collection of Amazon.IoTDeviceAdvisor.Model.SuiteRunInformation objects.",
        "The service call response (type Amazon.IoTDeviceAdvisor.Model.ListSuiteRunsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIOTDASuiteRunListCmdlet : AmazonIoTDeviceAdvisorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SuiteDefinitionId
        /// <summary>
        /// <para>
        /// <para>Lists the test suite runs of the specified test suite based on suite definition ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String SuiteDefinitionId { get; set; }
        #endregion
        
        #region Parameter SuiteDefinitionVersion
        /// <summary>
        /// <para>
        /// <para>Must be passed along with <c>suiteDefinitionId</c>. Lists the test suite runs of the
        /// specified test suite based on suite definition version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SuiteDefinitionVersion { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return at once.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token to retrieve the next set of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SuiteRunsList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTDeviceAdvisor.Model.ListSuiteRunsResponse).
        /// Specifying the name of a property of type Amazon.IoTDeviceAdvisor.Model.ListSuiteRunsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SuiteRunsList";
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
                context.Select = CreateSelectDelegate<Amazon.IoTDeviceAdvisor.Model.ListSuiteRunsResponse, GetIOTDASuiteRunListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.SuiteDefinitionId = this.SuiteDefinitionId;
            context.SuiteDefinitionVersion = this.SuiteDefinitionVersion;
            
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
            var request = new Amazon.IoTDeviceAdvisor.Model.ListSuiteRunsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.SuiteDefinitionId != null)
            {
                request.SuiteDefinitionId = cmdletContext.SuiteDefinitionId;
            }
            if (cmdletContext.SuiteDefinitionVersion != null)
            {
                request.SuiteDefinitionVersion = cmdletContext.SuiteDefinitionVersion;
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
        
        private Amazon.IoTDeviceAdvisor.Model.ListSuiteRunsResponse CallAWSServiceOperation(IAmazonIoTDeviceAdvisor client, Amazon.IoTDeviceAdvisor.Model.ListSuiteRunsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Core Device Advisor", "ListSuiteRuns");
            try
            {
                return client.ListSuiteRunsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String SuiteDefinitionId { get; set; }
            public System.String SuiteDefinitionVersion { get; set; }
            public System.Func<Amazon.IoTDeviceAdvisor.Model.ListSuiteRunsResponse, GetIOTDASuiteRunListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SuiteRunsList;
        }
        
    }
}
