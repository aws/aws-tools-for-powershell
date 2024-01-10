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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// This API is in preview release for Amazon Connect and is subject to change.
    /// 
    ///  
    /// <para>
    /// Creates a new queue for the specified Amazon Connect instance.
    /// </para><important><ul><li><para>
    /// If the phone number is claimed to a traffic distribution group that was created in
    /// the same Region as the Amazon Connect instance where you are calling this API, then
    /// you can use a full phone number ARN or a UUID for <c>OutboundCallerIdNumberId</c>.
    /// However, if the phone number is claimed to a traffic distribution group that is in
    /// one Region, and you are calling this API from an instance in another Amazon Web Services
    /// Region that is associated with the traffic distribution group, you must provide a
    /// full phone number ARN. If a UUID is provided in this scenario, you will receive a
    /// <c>ResourceNotFoundException</c>.
    /// </para></li><li><para>
    /// Only use the phone number ARN format that doesn't contain <c>instance</c> in the path,
    /// for example, <c>arn:aws:connect:us-east-1:1234567890:phone-number/uuid</c>. This is
    /// the same ARN format that is returned when you call the <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_ListPhoneNumbersV2.html">ListPhoneNumbersV2</a>
    /// API.
    /// </para></li><li><para>
    /// If you plan to use IAM policies to allow/deny access to this API for phone number
    /// resources claimed to a traffic distribution group, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/security_iam_resource-level-policy-examples.html#allow-deny-queue-actions-replica-region">Allow
    /// or Deny queue API actions for phone numbers in a replica Region</a>.
    /// </para></li></ul></important>
    /// </summary>
    [Cmdlet("New", "CONNQueue", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Connect.Model.CreateQueueResponse")]
    [AWSCmdlet("Calls the Amazon Connect Service CreateQueue API operation.", Operation = new[] {"CreateQueue"}, SelectReturnType = typeof(Amazon.Connect.Model.CreateQueueResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.CreateQueueResponse",
        "This cmdlet returns an Amazon.Connect.Model.CreateQueueResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCONNQueueCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the queue.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter HoursOfOperationId
        /// <summary>
        /// <para>
        /// <para>The identifier for the hours of operation.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String HoursOfOperationId { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter MaxContact
        /// <summary>
        /// <para>
        /// <para>The maximum number of contacts that can be in the queue before it is considered full.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxContacts")]
        public System.Int32? MaxContact { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the queue.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter OutboundCallerConfig_OutboundCallerIdName
        /// <summary>
        /// <para>
        /// <para>The caller ID name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutboundCallerConfig_OutboundCallerIdName { get; set; }
        #endregion
        
        #region Parameter OutboundCallerConfig_OutboundCallerIdNumberId
        /// <summary>
        /// <para>
        /// <para>The caller ID number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutboundCallerConfig_OutboundCallerIdNumberId { get; set; }
        #endregion
        
        #region Parameter OutboundCallerConfig_OutboundFlowId
        /// <summary>
        /// <para>
        /// <para>The outbound whisper flow to be used during an outbound call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutboundCallerConfig_OutboundFlowId { get; set; }
        #endregion
        
        #region Parameter QuickConnectId
        /// <summary>
        /// <para>
        /// <para>The quick connects available to agents who are working the queue.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("QuickConnectIds")]
        public System.String[] QuickConnectId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags used to organize, track, or control access for this resource. For example,
        /// { "Tags": {"key1":"value1", "key2":"value2"} }.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.CreateQueueResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.CreateQueueResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CONNQueue (CreateQueue)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.CreateQueueResponse, NewCONNQueueCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            context.HoursOfOperationId = this.HoursOfOperationId;
            #if MODULAR
            if (this.HoursOfOperationId == null && ParameterWasBound(nameof(this.HoursOfOperationId)))
            {
                WriteWarning("You are passing $null as a value for parameter HoursOfOperationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxContact = this.MaxContact;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutboundCallerConfig_OutboundCallerIdName = this.OutboundCallerConfig_OutboundCallerIdName;
            context.OutboundCallerConfig_OutboundCallerIdNumberId = this.OutboundCallerConfig_OutboundCallerIdNumberId;
            context.OutboundCallerConfig_OutboundFlowId = this.OutboundCallerConfig_OutboundFlowId;
            if (this.QuickConnectId != null)
            {
                context.QuickConnectId = new List<System.String>(this.QuickConnectId);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.Connect.Model.CreateQueueRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.HoursOfOperationId != null)
            {
                request.HoursOfOperationId = cmdletContext.HoursOfOperationId;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.MaxContact != null)
            {
                request.MaxContacts = cmdletContext.MaxContact.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate OutboundCallerConfig
            var requestOutboundCallerConfigIsNull = true;
            request.OutboundCallerConfig = new Amazon.Connect.Model.OutboundCallerConfig();
            System.String requestOutboundCallerConfig_outboundCallerConfig_OutboundCallerIdName = null;
            if (cmdletContext.OutboundCallerConfig_OutboundCallerIdName != null)
            {
                requestOutboundCallerConfig_outboundCallerConfig_OutboundCallerIdName = cmdletContext.OutboundCallerConfig_OutboundCallerIdName;
            }
            if (requestOutboundCallerConfig_outboundCallerConfig_OutboundCallerIdName != null)
            {
                request.OutboundCallerConfig.OutboundCallerIdName = requestOutboundCallerConfig_outboundCallerConfig_OutboundCallerIdName;
                requestOutboundCallerConfigIsNull = false;
            }
            System.String requestOutboundCallerConfig_outboundCallerConfig_OutboundCallerIdNumberId = null;
            if (cmdletContext.OutboundCallerConfig_OutboundCallerIdNumberId != null)
            {
                requestOutboundCallerConfig_outboundCallerConfig_OutboundCallerIdNumberId = cmdletContext.OutboundCallerConfig_OutboundCallerIdNumberId;
            }
            if (requestOutboundCallerConfig_outboundCallerConfig_OutboundCallerIdNumberId != null)
            {
                request.OutboundCallerConfig.OutboundCallerIdNumberId = requestOutboundCallerConfig_outboundCallerConfig_OutboundCallerIdNumberId;
                requestOutboundCallerConfigIsNull = false;
            }
            System.String requestOutboundCallerConfig_outboundCallerConfig_OutboundFlowId = null;
            if (cmdletContext.OutboundCallerConfig_OutboundFlowId != null)
            {
                requestOutboundCallerConfig_outboundCallerConfig_OutboundFlowId = cmdletContext.OutboundCallerConfig_OutboundFlowId;
            }
            if (requestOutboundCallerConfig_outboundCallerConfig_OutboundFlowId != null)
            {
                request.OutboundCallerConfig.OutboundFlowId = requestOutboundCallerConfig_outboundCallerConfig_OutboundFlowId;
                requestOutboundCallerConfigIsNull = false;
            }
             // determine if request.OutboundCallerConfig should be set to null
            if (requestOutboundCallerConfigIsNull)
            {
                request.OutboundCallerConfig = null;
            }
            if (cmdletContext.QuickConnectId != null)
            {
                request.QuickConnectIds = cmdletContext.QuickConnectId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Connect.Model.CreateQueueResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.CreateQueueRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "CreateQueue");
            try
            {
                #if DESKTOP
                return client.CreateQueue(request);
                #elif CORECLR
                return client.CreateQueueAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String HoursOfOperationId { get; set; }
            public System.String InstanceId { get; set; }
            public System.Int32? MaxContact { get; set; }
            public System.String Name { get; set; }
            public System.String OutboundCallerConfig_OutboundCallerIdName { get; set; }
            public System.String OutboundCallerConfig_OutboundCallerIdNumberId { get; set; }
            public System.String OutboundCallerConfig_OutboundFlowId { get; set; }
            public List<System.String> QuickConnectId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Connect.Model.CreateQueueResponse, NewCONNQueueCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
