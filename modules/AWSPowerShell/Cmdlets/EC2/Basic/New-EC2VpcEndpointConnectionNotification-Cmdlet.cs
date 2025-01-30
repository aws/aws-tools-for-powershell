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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates a connection notification for a specified VPC endpoint or VPC endpoint service.
    /// A connection notification notifies you of specific endpoint events. You must create
    /// an SNS topic to receive notifications. For more information, see <a href="https://docs.aws.amazon.com/sns/latest/dg/CreateTopic.html">Creating
    /// an Amazon SNS topic</a> in the <i>Amazon SNS Developer Guide</i>.
    /// 
    ///  
    /// <para>
    /// You can create a connection notification for interface endpoints only.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2VpcEndpointConnectionNotification", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.CreateVpcEndpointConnectionNotificationResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateVpcEndpointConnectionNotification API operation.", Operation = new[] {"CreateVpcEndpointConnectionNotification"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateVpcEndpointConnectionNotificationResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.CreateVpcEndpointConnectionNotificationResponse",
        "This cmdlet returns an Amazon.EC2.Model.CreateVpcEndpointConnectionNotificationResponse object containing multiple properties."
    )]
    public partial class NewEC2VpcEndpointConnectionNotificationCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConnectionEvent
        /// <summary>
        /// <para>
        /// <para>The endpoint events for which to receive notifications. Valid values are <c>Accept</c>,
        /// <c>Connect</c>, <c>Delete</c>, and <c>Reject</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ConnectionEvents")]
        public System.String[] ConnectionEvent { get; set; }
        #endregion
        
        #region Parameter ConnectionNotificationArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the SNS topic for the notifications.</para>
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
        public System.String ConnectionNotificationArn { get; set; }
        #endregion
        
        #region Parameter ServiceId
        /// <summary>
        /// <para>
        /// <para>The ID of the endpoint service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceId { get; set; }
        #endregion
        
        #region Parameter VpcEndpointId
        /// <summary>
        /// <para>
        /// <para>The ID of the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VpcEndpointId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. For more information, see <a href="https://docs.aws.amazon.com/ec2/latest/devguide/ec2-api-idempotency.html">How
        /// to ensure idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateVpcEndpointConnectionNotificationResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateVpcEndpointConnectionNotificationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConnectionNotificationArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConnectionNotificationArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConnectionNotificationArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectionNotificationArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2VpcEndpointConnectionNotification (CreateVpcEndpointConnectionNotification)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateVpcEndpointConnectionNotificationResponse, NewEC2VpcEndpointConnectionNotificationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConnectionNotificationArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            if (this.ConnectionEvent != null)
            {
                context.ConnectionEvent = new List<System.String>(this.ConnectionEvent);
            }
            #if MODULAR
            if (this.ConnectionEvent == null && ParameterWasBound(nameof(this.ConnectionEvent)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectionEvent which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConnectionNotificationArn = this.ConnectionNotificationArn;
            #if MODULAR
            if (this.ConnectionNotificationArn == null && ParameterWasBound(nameof(this.ConnectionNotificationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectionNotificationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceId = this.ServiceId;
            context.VpcEndpointId = this.VpcEndpointId;
            
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
            var request = new Amazon.EC2.Model.CreateVpcEndpointConnectionNotificationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ConnectionEvent != null)
            {
                request.ConnectionEvents = cmdletContext.ConnectionEvent;
            }
            if (cmdletContext.ConnectionNotificationArn != null)
            {
                request.ConnectionNotificationArn = cmdletContext.ConnectionNotificationArn;
            }
            if (cmdletContext.ServiceId != null)
            {
                request.ServiceId = cmdletContext.ServiceId;
            }
            if (cmdletContext.VpcEndpointId != null)
            {
                request.VpcEndpointId = cmdletContext.VpcEndpointId;
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
        
        private Amazon.EC2.Model.CreateVpcEndpointConnectionNotificationResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateVpcEndpointConnectionNotificationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateVpcEndpointConnectionNotification");
            try
            {
                #if DESKTOP
                return client.CreateVpcEndpointConnectionNotification(request);
                #elif CORECLR
                return client.CreateVpcEndpointConnectionNotificationAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public List<System.String> ConnectionEvent { get; set; }
            public System.String ConnectionNotificationArn { get; set; }
            public System.String ServiceId { get; set; }
            public System.String VpcEndpointId { get; set; }
            public System.Func<Amazon.EC2.Model.CreateVpcEndpointConnectionNotificationResponse, NewEC2VpcEndpointConnectionNotificationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
