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
using Amazon.AWSMarketplaceMetering;
using Amazon.AWSMarketplaceMetering.Model;

namespace Amazon.PowerShell.Cmdlets.MM
{
    /// <summary>
    /// BatchMeterUsage is called from a SaaS application listed on the AWS Marketplace to
    /// post metering records for a set of customers.
    /// 
    ///  
    /// <para>
    /// For identical requests, the API is idempotent; requests can be retried with the same
    /// records or a subset of the input records.
    /// </para><para>
    /// Every request to BatchMeterUsage is for one product. If you need to meter usage for
    /// multiple products, you must make multiple calls to BatchMeterUsage.
    /// </para><para>
    /// BatchMeterUsage can process up to 25 UsageRecords at a time.
    /// </para>
    /// </summary>
    [Cmdlet("Send", "MMMeteringDataBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AWSMarketplaceMetering.Model.BatchMeterUsageResponse")]
    [AWSCmdlet("Invokes the BatchMeterUsage operation against AWS Marketplace Metering.", Operation = new[] {"BatchMeterUsage"})]
    [AWSCmdletOutput("Amazon.AWSMarketplaceMetering.Model.BatchMeterUsageResponse",
        "This cmdlet returns a Amazon.AWSMarketplaceMetering.Model.BatchMeterUsageResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendMMMeteringDataBatchCmdlet : AmazonAWSMarketplaceMeteringClientCmdlet, IExecutor
    {
        
        #region Parameter ProductCode
        /// <summary>
        /// <para>
        /// <para>Product code is used to uniquely identify a product in AWS Marketplace. The product
        /// code should be the same as the one used during the publishing of a new product.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ProductCode { get; set; }
        #endregion
        
        #region Parameter UsageRecord
        /// <summary>
        /// <para>
        /// <para>The set of UsageRecords to submit. BatchMeterUsage accepts up to 25 UsageRecords at
        /// a time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("UsageRecords")]
        public Amazon.AWSMarketplaceMetering.Model.UsageRecord[] UsageRecord { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ProductCode", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-MMMeteringDataBatch (BatchMeterUsage)"))
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
            
            context.ProductCode = this.ProductCode;
            if (this.UsageRecord != null)
            {
                context.UsageRecords = new List<Amazon.AWSMarketplaceMetering.Model.UsageRecord>(this.UsageRecord);
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
            var request = new Amazon.AWSMarketplaceMetering.Model.BatchMeterUsageRequest();
            
            if (cmdletContext.ProductCode != null)
            {
                request.ProductCode = cmdletContext.ProductCode;
            }
            if (cmdletContext.UsageRecords != null)
            {
                request.UsageRecords = cmdletContext.UsageRecords;
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
        
        private Amazon.AWSMarketplaceMetering.Model.BatchMeterUsageResponse CallAWSServiceOperation(IAmazonAWSMarketplaceMetering client, Amazon.AWSMarketplaceMetering.Model.BatchMeterUsageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Marketplace Metering", "BatchMeterUsage");
            try
            {
                #if DESKTOP
                return client.BatchMeterUsage(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.BatchMeterUsageAsync(request);
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
            public System.String ProductCode { get; set; }
            public List<Amazon.AWSMarketplaceMetering.Model.UsageRecord> UsageRecords { get; set; }
        }
        
    }
}
