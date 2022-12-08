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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Gets the status of Service Catalog in SageMaker. Service Catalog is used to create
    /// SageMaker projects.
    /// </summary>
    [Cmdlet("Get", "SMSagemakerServicecatalogPortfolioStatus")]
    [OutputType("Amazon.SageMaker.SagemakerServicecatalogStatus")]
    [AWSCmdlet("Calls the Amazon SageMaker Service GetSagemakerServicecatalogPortfolioStatus API operation.", Operation = new[] {"GetSagemakerServicecatalogPortfolioStatus"}, SelectReturnType = typeof(Amazon.SageMaker.Model.GetSagemakerServicecatalogPortfolioStatusResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.SagemakerServicecatalogStatus or Amazon.SageMaker.Model.GetSagemakerServicecatalogPortfolioStatusResponse",
        "This cmdlet returns an Amazon.SageMaker.SagemakerServicecatalogStatus object.",
        "The service call response (type Amazon.SageMaker.Model.GetSagemakerServicecatalogPortfolioStatusResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSMSagemakerServicecatalogPortfolioStatusCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Status'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.GetSagemakerServicecatalogPortfolioStatusResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.GetSagemakerServicecatalogPortfolioStatusResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Status";
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
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.GetSagemakerServicecatalogPortfolioStatusResponse, GetSMSagemakerServicecatalogPortfolioStatusCmdlet>(Select) ??
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
            var request = new Amazon.SageMaker.Model.GetSagemakerServicecatalogPortfolioStatusRequest();
            
            
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
        
        private Amazon.SageMaker.Model.GetSagemakerServicecatalogPortfolioStatusResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.GetSagemakerServicecatalogPortfolioStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "GetSagemakerServicecatalogPortfolioStatus");
            try
            {
                #if DESKTOP
                return client.GetSagemakerServicecatalogPortfolioStatus(request);
                #elif CORECLR
                return client.GetSagemakerServicecatalogPortfolioStatusAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.SageMaker.Model.GetSagemakerServicecatalogPortfolioStatusResponse, GetSMSagemakerServicecatalogPortfolioStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Status;
        }
        
    }
}
