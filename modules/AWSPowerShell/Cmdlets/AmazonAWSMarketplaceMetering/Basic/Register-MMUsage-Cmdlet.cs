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
using Amazon.AWSMarketplaceMetering;
using Amazon.AWSMarketplaceMetering.Model;

namespace Amazon.PowerShell.Cmdlets.MM
{
    /// <summary>
    /// Paid container software products sold through AWS Marketplace must integrate with
    /// the AWS Marketplace Metering Service and call the RegisterUsage operation for software
    /// entitlement and metering. Calling RegisterUsage from containers running outside of
    /// ECS is not currently supported. Free and BYOL products for ECS aren't required to
    /// call RegisterUsage, but you may choose to do so if you would like to receive usage
    /// data in your seller reports. The sections below explain the behavior of RegisterUsage.
    /// RegisterUsage performs two primary functions: metering and entitlement.
    /// 
    ///  <ul><li><para><i>Entitlement</i>: RegisterUsage allows you to verify that the customer running
    /// your paid software is subscribed to your product on AWS Marketplace, enabling you
    /// to guard against unauthorized use. Your container image that integrates with RegisterUsage
    /// is only required to guard against unauthorized use at container startup, as such a
    /// CustomerNotSubscribedException/PlatformNotSupportedException will only be thrown on
    /// the initial call to RegisterUsage. Subsequent calls from the same Amazon ECS task
    /// instance (e.g. task-id) will not throw a CustomerNotSubscribedException, even if the
    /// customer unsubscribes while the Amazon ECS task is still running.
    /// </para></li><li><para><i>Metering</i>: RegisterUsage meters software use per ECS task, per hour, with usage
    /// prorated to the second. A minimum of 1 minute of usage applies to tasks that are short
    /// lived. For example, if a customer has a 10 node ECS cluster and creates an ECS service
    /// configured as a Daemon Set, then ECS will launch a task on all 10 cluster nodes and
    /// the customer will be charged: (10 * hourly_rate). Metering for software use is automatically
    /// handled by the AWS Marketplace Metering Control Plane -- your software is not required
    /// to perform any metering specific actions, other than call RegisterUsage once for metering
    /// of software use to commence. The AWS Marketplace Metering Control Plane will also
    /// continue to bill customers for running ECS tasks, regardless of the customers subscription
    /// state, removing the need for your software to perform entitlement checks at runtime.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Register", "MMUsage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AWSMarketplaceMetering.Model.RegisterUsageResponse")]
    [AWSCmdlet("Calls the AWS Marketplace Metering RegisterUsage API operation.", Operation = new[] {"RegisterUsage"})]
    [AWSCmdletOutput("Amazon.AWSMarketplaceMetering.Model.RegisterUsageResponse",
        "This cmdlet returns a Amazon.AWSMarketplaceMetering.Model.RegisterUsageResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterMMUsageCmdlet : AmazonAWSMarketplaceMeteringClientCmdlet, IExecutor
    {
        
        #region Parameter Nonce
        /// <summary>
        /// <para>
        /// <para>(Optional) To scope down the registration to a specific running software instance
        /// and guard against replay attacks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Nonce { get; set; }
        #endregion
        
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
        
        #region Parameter PublicKeyVersion
        /// <summary>
        /// <para>
        /// <para>Public Key Version provided by AWS Marketplace</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 PublicKeyVersion { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-MMUsage (RegisterUsage)"))
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
            
            context.Nonce = this.Nonce;
            context.ProductCode = this.ProductCode;
            if (ParameterWasBound("PublicKeyVersion"))
                context.PublicKeyVersion = this.PublicKeyVersion;
            
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
            var request = new Amazon.AWSMarketplaceMetering.Model.RegisterUsageRequest();
            
            if (cmdletContext.Nonce != null)
            {
                request.Nonce = cmdletContext.Nonce;
            }
            if (cmdletContext.ProductCode != null)
            {
                request.ProductCode = cmdletContext.ProductCode;
            }
            if (cmdletContext.PublicKeyVersion != null)
            {
                request.PublicKeyVersion = cmdletContext.PublicKeyVersion.Value;
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
        
        private Amazon.AWSMarketplaceMetering.Model.RegisterUsageResponse CallAWSServiceOperation(IAmazonAWSMarketplaceMetering client, Amazon.AWSMarketplaceMetering.Model.RegisterUsageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Marketplace Metering", "RegisterUsage");
            try
            {
                #if DESKTOP
                return client.RegisterUsage(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.RegisterUsageAsync(request);
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
            public System.String Nonce { get; set; }
            public System.String ProductCode { get; set; }
            public System.Int32? PublicKeyVersion { get; set; }
        }
        
    }
}
