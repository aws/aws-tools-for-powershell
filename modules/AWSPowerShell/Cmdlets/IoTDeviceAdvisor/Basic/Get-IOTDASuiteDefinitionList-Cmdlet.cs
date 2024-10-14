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
using Amazon.IoTDeviceAdvisor;
using Amazon.IoTDeviceAdvisor.Model;

namespace Amazon.PowerShell.Cmdlets.IOTDA
{
    /// <summary>
    /// Lists the Device Advisor test suites you have created.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">ListSuiteDefinitions</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "IOTDASuiteDefinitionList")]
    [OutputType("Amazon.IoTDeviceAdvisor.Model.SuiteDefinitionInformation")]
    [AWSCmdlet("Calls the AWS IoT Core Device Advisor ListSuiteDefinitions API operation.", Operation = new[] {"ListSuiteDefinitions"}, SelectReturnType = typeof(Amazon.IoTDeviceAdvisor.Model.ListSuiteDefinitionsResponse))]
    [AWSCmdletOutput("Amazon.IoTDeviceAdvisor.Model.SuiteDefinitionInformation or Amazon.IoTDeviceAdvisor.Model.ListSuiteDefinitionsResponse",
        "This cmdlet returns a collection of Amazon.IoTDeviceAdvisor.Model.SuiteDefinitionInformation objects.",
        "The service call response (type Amazon.IoTDeviceAdvisor.Model.ListSuiteDefinitionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIOTDASuiteDefinitionListCmdlet : AmazonIoTDeviceAdvisorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        /// <para>A token used to get the next set of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SuiteDefinitionInformationList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTDeviceAdvisor.Model.ListSuiteDefinitionsResponse).
        /// Specifying the name of a property of type Amazon.IoTDeviceAdvisor.Model.ListSuiteDefinitionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SuiteDefinitionInformationList";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTDeviceAdvisor.Model.ListSuiteDefinitionsResponse, GetIOTDASuiteDefinitionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.IoTDeviceAdvisor.Model.ListSuiteDefinitionsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.IoTDeviceAdvisor.Model.ListSuiteDefinitionsResponse CallAWSServiceOperation(IAmazonIoTDeviceAdvisor client, Amazon.IoTDeviceAdvisor.Model.ListSuiteDefinitionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Core Device Advisor", "ListSuiteDefinitions");
            try
            {
                #if DESKTOP
                return client.ListSuiteDefinitions(request);
                #elif CORECLR
                return client.ListSuiteDefinitionsAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.IoTDeviceAdvisor.Model.ListSuiteDefinitionsResponse, GetIOTDASuiteDefinitionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SuiteDefinitionInformationList;
        }
        
    }
}
