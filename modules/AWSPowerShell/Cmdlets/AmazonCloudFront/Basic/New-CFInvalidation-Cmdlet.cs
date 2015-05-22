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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Create a new invalidation.
    /// </summary>
    [Cmdlet("New", "CFInvalidation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.CreateInvalidationResponse")]
    [AWSCmdlet("Invokes the CreateInvalidation operation against Amazon CloudFront.", Operation = new[] {"CreateInvalidation"})]
    [AWSCmdletOutput("Amazon.CloudFront.Model.CreateInvalidationResponse",
        "This cmdlet returns a CreateInvalidationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewCFInvalidationCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// A unique name that ensures the request
        /// can't be replayed. If the CallerReference is new (no matter the content of the Path
        /// object), a new distribution is created. If the CallerReference is a value you already
        /// sent in a previous request to create an invalidation batch, and the content of each
        /// Path element is identical to the original request, the response includes the same
        /// information returned to the original request. If the CallerReference is a value you
        /// already sent in a previous request to create a distribution but the content of any
        /// Path is different from the original request, CloudFront returns an InvalidationBatchAlreadyExists
        /// error.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String InvalidationBatch_CallerReference { get; set; }
        
        /// <summary>
        /// <para>
        /// The distribution's id.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String DistributionId { get; set; }
        
        /// <summary>
        /// <para>
        /// A complex type that contains a list of the objects
        /// that you want to invalidate.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InvalidationBatch_Paths_Items")]
        public System.String[] Paths_Item { get; set; }
        
        /// <summary>
        /// <para>
        /// The number of objects that you want to invalidate.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InvalidationBatch_Paths_Quantity")]
        public Int32 Paths_Quantity { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
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
            
            context.DistributionId = this.DistributionId;
            context.InvalidationBatch_CallerReference = this.InvalidationBatch_CallerReference;
            if (this.Paths_Item != null)
            {
                context.InvalidationBatch_Paths_Items = new List<String>(this.Paths_Item);
            }
            if (ParameterWasBound("Paths_Quantity"))
                context.InvalidationBatch_Paths_Quantity = this.Paths_Quantity;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CreateInvalidationRequest();
            
            if (cmdletContext.DistributionId != null)
            {
                request.DistributionId = cmdletContext.DistributionId;
            }
            
             // populate InvalidationBatch
            bool requestInvalidationBatchIsNull = true;
            request.InvalidationBatch = new InvalidationBatch();
            String requestInvalidationBatch_invalidationBatch_CallerReference = null;
            if (cmdletContext.InvalidationBatch_CallerReference != null)
            {
                requestInvalidationBatch_invalidationBatch_CallerReference = cmdletContext.InvalidationBatch_CallerReference;
            }
            if (requestInvalidationBatch_invalidationBatch_CallerReference != null)
            {
                request.InvalidationBatch.CallerReference = requestInvalidationBatch_invalidationBatch_CallerReference;
                requestInvalidationBatchIsNull = false;
            }
            Paths requestInvalidationBatch_invalidationBatch_Paths = null;
            
             // populate Paths
            bool requestInvalidationBatch_invalidationBatch_PathsIsNull = true;
            requestInvalidationBatch_invalidationBatch_Paths = new Paths();
            List<String> requestInvalidationBatch_invalidationBatch_Paths_paths_Item = null;
            if (cmdletContext.InvalidationBatch_Paths_Items != null)
            {
                requestInvalidationBatch_invalidationBatch_Paths_paths_Item = cmdletContext.InvalidationBatch_Paths_Items;
            }
            if (requestInvalidationBatch_invalidationBatch_Paths_paths_Item != null)
            {
                requestInvalidationBatch_invalidationBatch_Paths.Items = requestInvalidationBatch_invalidationBatch_Paths_paths_Item;
                requestInvalidationBatch_invalidationBatch_PathsIsNull = false;
            }
            Int32? requestInvalidationBatch_invalidationBatch_Paths_paths_Quantity = null;
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
                var response = client.CreateInvalidation(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String DistributionId { get; set; }
            public String InvalidationBatch_CallerReference { get; set; }
            public List<String> InvalidationBatch_Paths_Items { get; set; }
            public Int32? InvalidationBatch_Paths_Quantity { get; set; }
        }
        
    }
}
