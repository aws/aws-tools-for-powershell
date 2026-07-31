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
using Amazon.Resiliencehubv2;
using Amazon.Resiliencehubv2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RH2
{
    /// <summary>
    /// Lists the available resilience test templates. A test template is a pre-configured,
    /// AWS recommended test that defines which resilience capability to validate.
    /// </summary>
    [Cmdlet("Get", "RH2TestTemplateList")]
    [OutputType("Amazon.Resiliencehubv2.Model.TestTemplateSummary")]
    [AWSCmdlet("Calls the AWS Resilience Hub V2 ListTestTemplates API operation.", Operation = new[] {"ListTestTemplates"}, SelectReturnType = typeof(Amazon.Resiliencehubv2.Model.ListTestTemplatesResponse))]
    [AWSCmdletOutput("Amazon.Resiliencehubv2.Model.TestTemplateSummary or Amazon.Resiliencehubv2.Model.ListTestTemplatesResponse",
        "This cmdlet returns a collection of Amazon.Resiliencehubv2.Model.TestTemplateSummary objects.",
        "The service call response (type Amazon.Resiliencehubv2.Model.ListTestTemplatesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetRH2TestTemplateListCmdlet : AmazonResiliencehubv2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TestTemplates'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Resiliencehubv2.Model.ListTestTemplatesResponse).
        /// Specifying the name of a property of type Amazon.Resiliencehubv2.Model.ListTestTemplatesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TestTemplates";
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
                context.Select = CreateSelectDelegate<Amazon.Resiliencehubv2.Model.ListTestTemplatesResponse, GetRH2TestTemplateListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            
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
            var request = new Amazon.Resiliencehubv2.Model.ListTestTemplatesRequest();
            
            
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
        
        private Amazon.Resiliencehubv2.Model.ListTestTemplatesResponse CallAWSServiceOperation(IAmazonResiliencehubv2 client, Amazon.Resiliencehubv2.Model.ListTestTemplatesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resilience Hub V2", "ListTestTemplates");
            try
            {
                return client.ListTestTemplatesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.Resiliencehubv2.Model.ListTestTemplatesResponse, GetRH2TestTemplateListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TestTemplates;
        }
        
    }
}
