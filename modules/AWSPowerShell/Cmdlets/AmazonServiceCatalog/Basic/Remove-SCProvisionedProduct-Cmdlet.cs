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
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;

namespace Amazon.PowerShell.Cmdlets.SC
{
    /// <summary>
    /// Requests termination of an existing ProvisionedProduct object. If there are <code>Tags</code>
    /// associated with the object, they are terminated when the ProvisionedProduct object
    /// is terminated. 
    /// 
    ///  
    /// <para>
    /// This operation does not delete any records associated with the ProvisionedProduct
    /// object.
    /// </para><para>
    /// You can check the status of this request using the <a>DescribeRecord</a> operation.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "SCProvisionedProduct", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.ServiceCatalog.Model.RecordDetail")]
    [AWSCmdlet("Calls the AWS Service Catalog TerminateProvisionedProduct API operation.", Operation = new[] {"TerminateProvisionedProduct"})]
    [AWSCmdletOutput("Amazon.ServiceCatalog.Model.RecordDetail",
        "This cmdlet returns a RecordDetail object.",
        "The service call response (type Amazon.ServiceCatalog.Model.TerminateProvisionedProductResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveSCProvisionedProductCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
    {
        
        #region Parameter AcceptLanguage
        /// <summary>
        /// <para>
        /// <para>The language code.</para><ul><li><para><code>en</code> - English (default)</para></li><li><para><code>jp</code> - Japanese</para></li><li><para><code>zh</code> - Chinese</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AcceptLanguage { get; set; }
        #endregion
        
        #region Parameter IgnoreError
        /// <summary>
        /// <para>
        /// <para>If set to true, AWS Service Catalog stops managing the specified ProvisionedProduct
        /// object even if it cannot delete the underlying resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IgnoreErrors")]
        public System.Boolean IgnoreError { get; set; }
        #endregion
        
        #region Parameter ProvisionedProductId
        /// <summary>
        /// <para>
        /// <para>The identifier of the ProvisionedProduct object to terminate. Specify either <code>ProvisionedProductName</code>
        /// or <code>ProvisionedProductId</code>, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ProvisionedProductId { get; set; }
        #endregion
        
        #region Parameter ProvisionedProductName
        /// <summary>
        /// <para>
        /// <para>The name of the ProvisionedProduct object to terminate. Specify either <code>ProvisionedProductName</code>
        /// or <code>ProvisionedProductId</code>, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ProvisionedProductName { get; set; }
        #endregion
        
        #region Parameter TerminateToken
        /// <summary>
        /// <para>
        /// <para>An idempotency token that uniquely identifies the termination request. This token
        /// is only valid during the termination process. After the ProvisionedProduct object
        /// is terminated, further requests to terminate the same ProvisionedProduct object always
        /// return <b>ResourceNotFound</b> regardless of the value of <code>TerminateToken</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TerminateToken { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ProvisionedProductId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-SCProvisionedProduct (TerminateProvisionedProduct)"))
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
            
            context.AcceptLanguage = this.AcceptLanguage;
            if (ParameterWasBound("IgnoreError"))
                context.IgnoreErrors = this.IgnoreError;
            context.ProvisionedProductId = this.ProvisionedProductId;
            context.ProvisionedProductName = this.ProvisionedProductName;
            context.TerminateToken = this.TerminateToken;
            
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
            var request = new Amazon.ServiceCatalog.Model.TerminateProvisionedProductRequest();
            
            if (cmdletContext.AcceptLanguage != null)
            {
                request.AcceptLanguage = cmdletContext.AcceptLanguage;
            }
            if (cmdletContext.IgnoreErrors != null)
            {
                request.IgnoreErrors = cmdletContext.IgnoreErrors.Value;
            }
            if (cmdletContext.ProvisionedProductId != null)
            {
                request.ProvisionedProductId = cmdletContext.ProvisionedProductId;
            }
            if (cmdletContext.ProvisionedProductName != null)
            {
                request.ProvisionedProductName = cmdletContext.ProvisionedProductName;
            }
            if (cmdletContext.TerminateToken != null)
            {
                request.TerminateToken = cmdletContext.TerminateToken;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.RecordDetail;
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
        
        private Amazon.ServiceCatalog.Model.TerminateProvisionedProductResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.TerminateProvisionedProductRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "TerminateProvisionedProduct");
            try
            {
                #if DESKTOP
                return client.TerminateProvisionedProduct(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.TerminateProvisionedProductAsync(request);
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
            public System.String AcceptLanguage { get; set; }
            public System.Boolean? IgnoreErrors { get; set; }
            public System.String ProvisionedProductId { get; set; }
            public System.String ProvisionedProductName { get; set; }
            public System.String TerminateToken { get; set; }
        }
        
    }
}
