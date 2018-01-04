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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Create a new invalidation.
    /// </summary>
    [Cmdlet("New", "CFInvalidation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.CreateInvalidationResponse")]
    [AWSCmdlet("Calls the Amazon CloudFront CreateInvalidation API operation.", Operation = new[] {"CreateInvalidation"})]
    [AWSCmdletOutput("Amazon.CloudFront.Model.CreateInvalidationResponse",
        "This cmdlet returns a Amazon.CloudFront.Model.CreateInvalidationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCFInvalidationCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        #region Parameter InvalidationBatch_CallerReference
        /// <summary>
        /// <para>
        /// <para>A value that you specify to uniquely identify an invalidation request. CloudFront
        /// uses the value to prevent you from accidentally resubmitting an identical request.
        /// Whenever you create a new invalidation request, you must specify a new value for <code>CallerReference</code>
        /// and change other values in the request as applicable. One way to ensure that the value
        /// of <code>CallerReference</code> is unique is to use a <code>timestamp</code>, for
        /// example, <code>20120301090000</code>.</para><para>If you make a second invalidation request with the same value for <code>CallerReference</code>,
        /// and if the rest of the request is the same, CloudFront doesn't create a new invalidation
        /// request. Instead, CloudFront returns information about the invalidation request that
        /// you previously created with the same <code>CallerReference</code>.</para><para>If <code>CallerReference</code> is a value you already sent in a previous invalidation
        /// batch request but the content of any <code>Path</code> is different from the original
        /// request, CloudFront returns an <code>InvalidationBatchAlreadyExists</code> error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String InvalidationBatch_CallerReference { get; set; }
        #endregion
        
        #region Parameter DistributionId
        /// <summary>
        /// <para>
        /// <para>The distribution's id.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DistributionId { get; set; }
        #endregion
        
        #region Parameter Paths_Item
        /// <summary>
        /// <para>
        /// <para>A complex type that contains a list of the paths that you want to invalidate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InvalidationBatch_Paths_Items")]
        public System.String[] Paths_Item { get; set; }
        #endregion
        
        #region Parameter Paths_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of objects that you want to invalidate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InvalidationBatch_Paths_Quantity")]
        public System.Int32 Paths_Quantity { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DistributionId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CFInvalidation (CreateInvalidation)"))
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
            
            context.DistributionId = this.DistributionId;
            context.InvalidationBatch_CallerReference = this.InvalidationBatch_CallerReference;
            if (this.Paths_Item != null)
            {
                context.InvalidationBatch_Paths_Items = new List<System.String>(this.Paths_Item);
            }
            if (ParameterWasBound("Paths_Quantity"))
                context.InvalidationBatch_Paths_Quantity = this.Paths_Quantity;
            
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
            var request = new Amazon.CloudFront.Model.CreateInvalidationRequest();
            
            if (cmdletContext.DistributionId != null)
            {
                request.DistributionId = cmdletContext.DistributionId;
            }
            
             // populate InvalidationBatch
            bool requestInvalidationBatchIsNull = true;
            request.InvalidationBatch = new Amazon.CloudFront.Model.InvalidationBatch();
            System.String requestInvalidationBatch_invalidationBatch_CallerReference = null;
            if (cmdletContext.InvalidationBatch_CallerReference != null)
            {
                requestInvalidationBatch_invalidationBatch_CallerReference = cmdletContext.InvalidationBatch_CallerReference;
            }
            if (requestInvalidationBatch_invalidationBatch_CallerReference != null)
            {
                request.InvalidationBatch.CallerReference = requestInvalidationBatch_invalidationBatch_CallerReference;
                requestInvalidationBatchIsNull = false;
            }
            Amazon.CloudFront.Model.Paths requestInvalidationBatch_invalidationBatch_Paths = null;
            
             // populate Paths
            bool requestInvalidationBatch_invalidationBatch_PathsIsNull = true;
            requestInvalidationBatch_invalidationBatch_Paths = new Amazon.CloudFront.Model.Paths();
            List<System.String> requestInvalidationBatch_invalidationBatch_Paths_paths_Item = null;
            if (cmdletContext.InvalidationBatch_Paths_Items != null)
            {
                requestInvalidationBatch_invalidationBatch_Paths_paths_Item = cmdletContext.InvalidationBatch_Paths_Items;
            }
            if (requestInvalidationBatch_invalidationBatch_Paths_paths_Item != null)
            {
                requestInvalidationBatch_invalidationBatch_Paths.Items = requestInvalidationBatch_invalidationBatch_Paths_paths_Item;
                requestInvalidationBatch_invalidationBatch_PathsIsNull = false;
            }
            System.Int32? requestInvalidationBatch_invalidationBatch_Paths_paths_Quantity = null;
            if (cmdletContext.InvalidationBatch_Paths_Quantity != null)
            {
                requestInvalidationBatch_invalidationBatch_Paths_paths_Quantity = cmdletContext.InvalidationBatch_Paths_Quantity.Value;
            }
            if (requestInvalidationBatch_invalidationBatch_Paths_paths_Quantity != null)
            {
                requestInvalidationBatch_invalidationBatch_Paths.Quantity = requestInvalidationBatch_invalidationBatch_Paths_paths_Quantity.Value;
                requestInvalidationBatch_invalidationBatch_PathsIsNull = false;
            }
             // determine if requestInvalidationBatch_invalidationBatch_Paths should be set to null
            if (requestInvalidationBatch_invalidationBatch_PathsIsNull)
            {
                requestInvalidationBatch_invalidationBatch_Paths = null;
            }
            if (requestInvalidationBatch_invalidationBatch_Paths != null)
            {
                request.InvalidationBatch.Paths = requestInvalidationBatch_invalidationBatch_Paths;
                requestInvalidationBatchIsNull = false;
            }
             // determine if request.InvalidationBatch should be set to null
            if (requestInvalidationBatchIsNull)
            {
                request.InvalidationBatch = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.CloudFront.Model.CreateInvalidationResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.CreateInvalidationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "CreateInvalidation");
            try
            {
                #if DESKTOP
                return client.CreateInvalidation(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateInvalidationAsync(request);
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
            public System.String DistributionId { get; set; }
            public System.String InvalidationBatch_CallerReference { get; set; }
            public List<System.String> InvalidationBatch_Paths_Items { get; set; }
            public System.Int32? InvalidationBatch_Paths_Quantity { get; set; }
        }
        
    }
}
