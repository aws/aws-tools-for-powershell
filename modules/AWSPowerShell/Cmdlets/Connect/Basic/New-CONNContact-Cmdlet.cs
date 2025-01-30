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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Creates a new contact.
    /// </summary>
    [Cmdlet("New", "CONNContact", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Connect.Model.CreateContactResponse")]
    [AWSCmdlet("Calls the Amazon Connect Service CreateContact API operation.", Operation = new[] {"CreateContact"}, SelectReturnType = typeof(Amazon.Connect.Model.CreateContactResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.CreateContactResponse",
        "This cmdlet returns an Amazon.Connect.Model.CreateContactResponse object containing multiple properties."
    )]
    public partial class NewCONNContactCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>A custom key-value pair using an attribute map. The attributes are standard Amazon
        /// Connect attributes, and can be accessed in flows just like any other contact attributes.</para><para>There can be up to 32,768 UTF-8 bytes across all key-value pairs per contact. Attribute
        /// keys can include only alphanumeric, dash, and underscore characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        #endregion
        
        #region Parameter Channel
        /// <summary>
        /// <para>
        /// <para>The channel for the contact</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Connect.Channel")]
        public Amazon.Connect.Channel Channel { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ExpiryDurationInMinute
        /// <summary>
        /// <para>
        /// <para>Number of minutes the contact will be active for before expiring</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExpiryDurationInMinutes")]
        public System.Int32? ExpiryDurationInMinute { get; set; }
        #endregion
        
        #region Parameter InitiateAs
        /// <summary>
        /// <para>
        /// <para>Initial state of the contact when it's created</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.InitiateAs")]
        public Amazon.Connect.InitiateAs InitiateAs { get; set; }
        #endregion
        
        #region Parameter InitiationMethod
        /// <summary>
        /// <para>
        /// <para>Indicates how the contact was initiated.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Connect.ContactInitiationMethod")]
        public Amazon.Connect.ContactInitiationMethod InitiationMethod { get; set; }
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of a the contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Reference
        /// <summary>
        /// <para>
        /// <para>A formatted URL that is shown to an agent in the Contact Control Panel (CCP). Tasks
        /// can have the following reference types at the time of creation: URL | NUMBER | STRING
        /// | DATE | EMAIL | ATTACHMENT.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("References")]
        public System.Collections.Hashtable Reference { get; set; }
        #endregion
        
        #region Parameter RelatedContactId
        /// <summary>
        /// <para>
        /// <para>The identifier of the contact in this instance of Amazon Connect. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RelatedContactId { get; set; }
        #endregion
        
        #region Parameter SegmentAttribute
        /// <summary>
        /// <para>
        /// <para>A set of system defined key-value pairs stored on individual contact segments (unique
        /// contact ID) using an attribute map. The attributes are standard Amazon Connect attributes.
        /// They can be accessed in flows.</para><para>Attribute keys can include only alphanumeric, -, and _.</para><para>This field can be used to set Segment Contact Expiry as a duration in minutes.</para><note><para>To set contact expiry, a ValueMap must be specified containing the integer number
        /// of minutes the contact will be active for before expiring, with <c>SegmentAttributes</c>
        /// like { <c> "connect:ContactExpiry": {"ValueMap" : { "ExpiryDuration": { "ValueInteger":
        /// 135}}}}</c>. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SegmentAttributes")]
        public System.Collections.Hashtable SegmentAttribute { get; set; }
        #endregion
        
        #region Parameter UserInfo_UserId
        /// <summary>
        /// <para>
        /// <para>The user identifier for the contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserInfo_UserId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If not provided, the Amazon Web Services SDK populates this field. For
        /// more information about idempotency, see <a href="https://aws.amazon.com/builders-library/making-retries-safe-with-idempotent-APIs/">Making
        /// retries safe with idempotent APIs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.CreateContactResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.CreateContactResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CONNContact (CreateContact)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.CreateContactResponse, NewCONNContactCmdlet>(Select) ??
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
            if (this.Attribute != null)
            {
                context.Attribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attribute.Add((String)hashKey, (System.String)(this.Attribute[hashKey]));
                }
            }
            context.Channel = this.Channel;
            #if MODULAR
            if (this.Channel == null && ParameterWasBound(nameof(this.Channel)))
            {
                WriteWarning("You are passing $null as a value for parameter Channel which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.ExpiryDurationInMinute = this.ExpiryDurationInMinute;
            context.InitiateAs = this.InitiateAs;
            context.InitiationMethod = this.InitiationMethod;
            #if MODULAR
            if (this.InitiationMethod == null && ParameterWasBound(nameof(this.InitiationMethod)))
            {
                WriteWarning("You are passing $null as a value for parameter InitiationMethod which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            if (this.Reference != null)
            {
                context.Reference = new Dictionary<System.String, Amazon.Connect.Model.Reference>(StringComparer.Ordinal);
                foreach (var hashKey in this.Reference.Keys)
                {
                    context.Reference.Add((String)hashKey, (Amazon.Connect.Model.Reference)(this.Reference[hashKey]));
                }
            }
            context.RelatedContactId = this.RelatedContactId;
            if (this.SegmentAttribute != null)
            {
                context.SegmentAttribute = new Dictionary<System.String, Amazon.Connect.Model.SegmentAttributeValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.SegmentAttribute.Keys)
                {
                    context.SegmentAttribute.Add((String)hashKey, (Amazon.Connect.Model.SegmentAttributeValue)(this.SegmentAttribute[hashKey]));
                }
            }
            context.UserInfo_UserId = this.UserInfo_UserId;
            
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
            var request = new Amazon.Connect.Model.CreateContactRequest();
            
            if (cmdletContext.Attribute != null)
            {
                request.Attributes = cmdletContext.Attribute;
            }
            if (cmdletContext.Channel != null)
            {
                request.Channel = cmdletContext.Channel;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ExpiryDurationInMinute != null)
            {
                request.ExpiryDurationInMinutes = cmdletContext.ExpiryDurationInMinute.Value;
            }
            if (cmdletContext.InitiateAs != null)
            {
                request.InitiateAs = cmdletContext.InitiateAs;
            }
            if (cmdletContext.InitiationMethod != null)
            {
                request.InitiationMethod = cmdletContext.InitiationMethod;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Reference != null)
            {
                request.References = cmdletContext.Reference;
            }
            if (cmdletContext.RelatedContactId != null)
            {
                request.RelatedContactId = cmdletContext.RelatedContactId;
            }
            if (cmdletContext.SegmentAttribute != null)
            {
                request.SegmentAttributes = cmdletContext.SegmentAttribute;
            }
            
             // populate UserInfo
            var requestUserInfoIsNull = true;
            request.UserInfo = new Amazon.Connect.Model.UserInfo();
            System.String requestUserInfo_userInfo_UserId = null;
            if (cmdletContext.UserInfo_UserId != null)
            {
                requestUserInfo_userInfo_UserId = cmdletContext.UserInfo_UserId;
            }
            if (requestUserInfo_userInfo_UserId != null)
            {
                request.UserInfo.UserId = requestUserInfo_userInfo_UserId;
                requestUserInfoIsNull = false;
            }
             // determine if request.UserInfo should be set to null
            if (requestUserInfoIsNull)
            {
                request.UserInfo = null;
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
        
        private Amazon.Connect.Model.CreateContactResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.CreateContactRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "CreateContact");
            try
            {
                #if DESKTOP
                return client.CreateContact(request);
                #elif CORECLR
                return client.CreateContactAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> Attribute { get; set; }
            public Amazon.Connect.Channel Channel { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.Int32? ExpiryDurationInMinute { get; set; }
            public Amazon.Connect.InitiateAs InitiateAs { get; set; }
            public Amazon.Connect.ContactInitiationMethod InitiationMethod { get; set; }
            public System.String InstanceId { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, Amazon.Connect.Model.Reference> Reference { get; set; }
            public System.String RelatedContactId { get; set; }
            public Dictionary<System.String, Amazon.Connect.Model.SegmentAttributeValue> SegmentAttribute { get; set; }
            public System.String UserInfo_UserId { get; set; }
            public System.Func<Amazon.Connect.Model.CreateContactResponse, NewCONNContactCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
