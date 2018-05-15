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
using Amazon.Elasticsearch;
using Amazon.Elasticsearch.Model;

namespace Amazon.PowerShell.Cmdlets.ES
{
    /// <summary>
    /// Allows you to purchase reserved Elasticsearch instances.
    /// </summary>
    [Cmdlet("New", "ESReservedElasticsearchInstanceOffering", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Elasticsearch.Model.PurchaseReservedElasticsearchInstanceOfferingResponse")]
    [AWSCmdlet("Calls the Amazon Elasticsearch PurchaseReservedElasticsearchInstanceOffering API operation.", Operation = new[] {"PurchaseReservedElasticsearchInstanceOffering"})]
    [AWSCmdletOutput("Amazon.Elasticsearch.Model.PurchaseReservedElasticsearchInstanceOfferingResponse",
        "This cmdlet returns a Amazon.Elasticsearch.Model.PurchaseReservedElasticsearchInstanceOfferingResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewESReservedElasticsearchInstanceOfferingCmdlet : AmazonElasticsearchClientCmdlet, IExecutor
    {
        
        #region Parameter InstanceCount
        /// <summary>
        /// <para>
        /// <para>The number of Elasticsearch instances to reserve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 InstanceCount { get; set; }
        #endregion
        
        #region Parameter ReservationName
        /// <summary>
        /// <para>
        /// <para>A customer-specified identifier to track this reservation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ReservationName { get; set; }
        #endregion
        
        #region Parameter ReservedElasticsearchInstanceOfferingId
        /// <summary>
        /// <para>
        /// <para>The ID of the reserved Elasticsearch instance offering to purchase.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ReservedElasticsearchInstanceOfferingId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ReservedElasticsearchInstanceOfferingId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ESReservedElasticsearchInstanceOffering (PurchaseReservedElasticsearchInstanceOffering)"))
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
            
            if (ParameterWasBound("InstanceCount"))
                context.InstanceCount = this.InstanceCount;
            context.ReservationName = this.ReservationName;
            context.ReservedElasticsearchInstanceOfferingId = this.ReservedElasticsearchInstanceOfferingId;
            
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
            var request = new Amazon.Elasticsearch.Model.PurchaseReservedElasticsearchInstanceOfferingRequest();
            
            if (cmdletContext.InstanceCount != null)
            {
                request.InstanceCount = cmdletContext.InstanceCount.Value;
            }
            if (cmdletContext.ReservationName != null)
            {
                request.ReservationName = cmdletContext.ReservationName;
            }
            if (cmdletContext.ReservedElasticsearchInstanceOfferingId != null)
            {
                request.ReservedElasticsearchInstanceOfferingId = cmdletContext.ReservedElasticsearchInstanceOfferingId;
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
        
        private Amazon.Elasticsearch.Model.PurchaseReservedElasticsearchInstanceOfferingResponse CallAWSServiceOperation(IAmazonElasticsearch client, Amazon.Elasticsearch.Model.PurchaseReservedElasticsearchInstanceOfferingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elasticsearch", "PurchaseReservedElasticsearchInstanceOffering");
            try
            {
                #if DESKTOP
                return client.PurchaseReservedElasticsearchInstanceOffering(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PurchaseReservedElasticsearchInstanceOfferingAsync(request);
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
            public System.Int32? InstanceCount { get; set; }
            public System.String ReservationName { get; set; }
            public System.String ReservedElasticsearchInstanceOfferingId { get; set; }
        }
        
    }
}
