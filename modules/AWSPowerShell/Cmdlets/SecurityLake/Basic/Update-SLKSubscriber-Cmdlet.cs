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
using Amazon.SecurityLake;
using Amazon.SecurityLake.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SLK
{
    /// <summary>
    /// Updates an existing subscription for the given Amazon Security Lake account ID. You
    /// can update a subscriber by changing the sources that the subscriber consumes data
    /// from.
    /// </summary>
    [Cmdlet("Update", "SLKSubscriber", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecurityLake.Model.SubscriberResource")]
    [AWSCmdlet("Calls the Amazon Security Lake UpdateSubscriber API operation.", Operation = new[] {"UpdateSubscriber"}, SelectReturnType = typeof(Amazon.SecurityLake.Model.UpdateSubscriberResponse))]
    [AWSCmdletOutput("Amazon.SecurityLake.Model.SubscriberResource or Amazon.SecurityLake.Model.UpdateSubscriberResponse",
        "This cmdlet returns an Amazon.SecurityLake.Model.SubscriberResource object.",
        "The service call response (type Amazon.SecurityLake.Model.UpdateSubscriberResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateSLKSubscriberCmdlet : AmazonSecurityLakeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SubscriberIdentity_ExternalId
        /// <summary>
        /// <para>
        /// <para>The external ID used to establish trust relationship with the Amazon Web Services
        /// identity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubscriberIdentity_ExternalId { get; set; }
        #endregion
        
        #region Parameter SubscriberIdentity_Principal
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services identity principal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubscriberIdentity_Principal { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// <para>The supported Amazon Web Services services from which logs and events are collected.
        /// For the list of supported Amazon Web Services services, see the <a href="https://docs.aws.amazon.com/security-lake/latest/userguide/internal-sources.html">Amazon
        /// Security Lake User Guide</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Sources")]
        public Amazon.SecurityLake.Model.LogSourceResource[] Source { get; set; }
        #endregion
        
        #region Parameter SubscriberDescription
        /// <summary>
        /// <para>
        /// <para>The description of the Security Lake account subscriber.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubscriberDescription { get; set; }
        #endregion
        
        #region Parameter SubscriberId
        /// <summary>
        /// <para>
        /// <para>A value created by Security Lake that uniquely identifies your subscription.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SubscriberId { get; set; }
        #endregion
        
        #region Parameter SubscriberName
        /// <summary>
        /// <para>
        /// <para>The name of the Security Lake account subscriber.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubscriberName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Subscriber'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityLake.Model.UpdateSubscriberResponse).
        /// Specifying the name of a property of type Amazon.SecurityLake.Model.UpdateSubscriberResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Subscriber";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SubscriberId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SLKSubscriber (UpdateSubscriber)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityLake.Model.UpdateSubscriberResponse, UpdateSLKSubscriberCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Source != null)
            {
                context.Source = new List<Amazon.SecurityLake.Model.LogSourceResource>(this.Source);
            }
            context.SubscriberDescription = this.SubscriberDescription;
            context.SubscriberId = this.SubscriberId;
            #if MODULAR
            if (this.SubscriberId == null && ParameterWasBound(nameof(this.SubscriberId)))
            {
                WriteWarning("You are passing $null as a value for parameter SubscriberId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SubscriberIdentity_ExternalId = this.SubscriberIdentity_ExternalId;
            context.SubscriberIdentity_Principal = this.SubscriberIdentity_Principal;
            context.SubscriberName = this.SubscriberName;
            
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
            var request = new Amazon.SecurityLake.Model.UpdateSubscriberRequest();
            
            if (cmdletContext.Source != null)
            {
                request.Sources = cmdletContext.Source;
            }
            if (cmdletContext.SubscriberDescription != null)
            {
                request.SubscriberDescription = cmdletContext.SubscriberDescription;
            }
            if (cmdletContext.SubscriberId != null)
            {
                request.SubscriberId = cmdletContext.SubscriberId;
            }
            
             // populate SubscriberIdentity
            var requestSubscriberIdentityIsNull = true;
            request.SubscriberIdentity = new Amazon.SecurityLake.Model.AwsIdentity();
            System.String requestSubscriberIdentity_subscriberIdentity_ExternalId = null;
            if (cmdletContext.SubscriberIdentity_ExternalId != null)
            {
                requestSubscriberIdentity_subscriberIdentity_ExternalId = cmdletContext.SubscriberIdentity_ExternalId;
            }
            if (requestSubscriberIdentity_subscriberIdentity_ExternalId != null)
            {
                request.SubscriberIdentity.ExternalId = requestSubscriberIdentity_subscriberIdentity_ExternalId;
                requestSubscriberIdentityIsNull = false;
            }
            System.String requestSubscriberIdentity_subscriberIdentity_Principal = null;
            if (cmdletContext.SubscriberIdentity_Principal != null)
            {
                requestSubscriberIdentity_subscriberIdentity_Principal = cmdletContext.SubscriberIdentity_Principal;
            }
            if (requestSubscriberIdentity_subscriberIdentity_Principal != null)
            {
                request.SubscriberIdentity.Principal = requestSubscriberIdentity_subscriberIdentity_Principal;
                requestSubscriberIdentityIsNull = false;
            }
             // determine if request.SubscriberIdentity should be set to null
            if (requestSubscriberIdentityIsNull)
            {
                request.SubscriberIdentity = null;
            }
            if (cmdletContext.SubscriberName != null)
            {
                request.SubscriberName = cmdletContext.SubscriberName;
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
        
        private Amazon.SecurityLake.Model.UpdateSubscriberResponse CallAWSServiceOperation(IAmazonSecurityLake client, Amazon.SecurityLake.Model.UpdateSubscriberRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Security Lake", "UpdateSubscriber");
            try
            {
                return client.UpdateSubscriberAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.SecurityLake.Model.LogSourceResource> Source { get; set; }
            public System.String SubscriberDescription { get; set; }
            public System.String SubscriberId { get; set; }
            public System.String SubscriberIdentity_ExternalId { get; set; }
            public System.String SubscriberIdentity_Principal { get; set; }
            public System.String SubscriberName { get; set; }
            public System.Func<Amazon.SecurityLake.Model.UpdateSubscriberResponse, UpdateSLKSubscriberCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Subscriber;
        }
        
    }
}
