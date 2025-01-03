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
    /// Adds or updates user-defined contact information associated with the specified contact.
    /// At least one field to be updated must be present in the request.
    /// </para><important><para>
    /// You can add or update user-defined contact information for both ongoing and completed
    /// contacts.
    /// </para></important>
    /// </summary>
    [Cmdlet("Update", "CONNContact", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Connect Service UpdateContact API operation.", Operation = new[] {"UpdateContact"}, SelectReturnType = typeof(Amazon.Connect.Model.UpdateContactResponse))]
    [AWSCmdletOutput("None or Amazon.Connect.Model.UpdateContactResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Connect.Model.UpdateContactResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCONNContactCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CustomerEndpoint_Address
        /// <summary>
        /// <para>
        /// <para>Address of the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomerEndpoint_Address { get; set; }
        #endregion
        
        #region Parameter SystemEndpoint_Address
        /// <summary>
        /// <para>
        /// <para>Address of the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SystemEndpoint_Address { get; set; }
        #endregion
        
        #region Parameter ContactId
        /// <summary>
        /// <para>
        /// <para>The identifier of the contact. This is the identifier of the contact associated with
        /// the first interaction with your contact center.</para>
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
        public System.String ContactId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter QueueInfo_Id
        /// <summary>
        /// <para>
        /// <para>The identifier of the queue.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QueueInfo_Id { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Reference
        /// <summary>
        /// <para>
        /// <para>Well-formed data on contact, shown to agents on Contact Control Panel (CCP).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("References")]
        public System.Collections.Hashtable Reference { get; set; }
        #endregion
        
        #region Parameter SegmentAttribute
        /// <summary>
        /// <para>
        /// <para>A set of system defined key-value pairs stored on individual contact segments (unique
        /// contact ID) using an attribute map. The attributes are standard Amazon Connect attributes.
        /// They can be accessed in flows.</para><para>Attribute keys can include only alphanumeric, -, and _.</para><para>This field can be used to show channel subtype, such as <c>connect:Guide</c>.</para><para>Currently Contact Expiry is the only segment attribute which can be updated by using
        /// the UpdateContact API.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SegmentAttributes")]
        public System.Collections.Hashtable SegmentAttribute { get; set; }
        #endregion
        
        #region Parameter CustomerEndpoint_Type
        /// <summary>
        /// <para>
        /// <para>Type of the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.EndpointType")]
        public Amazon.Connect.EndpointType CustomerEndpoint_Type { get; set; }
        #endregion
        
        #region Parameter SystemEndpoint_Type
        /// <summary>
        /// <para>
        /// <para>Type of the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.EndpointType")]
        public Amazon.Connect.EndpointType SystemEndpoint_Type { get; set; }
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.UpdateContactResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ContactId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CONNContact (UpdateContact)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.UpdateContactResponse, UpdateCONNContactCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ContactId = this.ContactId;
            #if MODULAR
            if (this.ContactId == null && ParameterWasBound(nameof(this.ContactId)))
            {
                WriteWarning("You are passing $null as a value for parameter ContactId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CustomerEndpoint_Address = this.CustomerEndpoint_Address;
            context.CustomerEndpoint_Type = this.CustomerEndpoint_Type;
            context.Description = this.Description;
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            context.QueueInfo_Id = this.QueueInfo_Id;
            if (this.Reference != null)
            {
                context.Reference = new Dictionary<System.String, Amazon.Connect.Model.Reference>(StringComparer.Ordinal);
                foreach (var hashKey in this.Reference.Keys)
                {
                    context.Reference.Add((String)hashKey, (Amazon.Connect.Model.Reference)(this.Reference[hashKey]));
                }
            }
            if (this.SegmentAttribute != null)
            {
                context.SegmentAttribute = new Dictionary<System.String, Amazon.Connect.Model.SegmentAttributeValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.SegmentAttribute.Keys)
                {
                    context.SegmentAttribute.Add((String)hashKey, (Amazon.Connect.Model.SegmentAttributeValue)(this.SegmentAttribute[hashKey]));
                }
            }
            context.SystemEndpoint_Address = this.SystemEndpoint_Address;
            context.SystemEndpoint_Type = this.SystemEndpoint_Type;
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
            var request = new Amazon.Connect.Model.UpdateContactRequest();
            
            if (cmdletContext.ContactId != null)
            {
                request.ContactId = cmdletContext.ContactId;
            }
            
             // populate CustomerEndpoint
            var requestCustomerEndpointIsNull = true;
            request.CustomerEndpoint = new Amazon.Connect.Model.Endpoint();
            System.String requestCustomerEndpoint_customerEndpoint_Address = null;
            if (cmdletContext.CustomerEndpoint_Address != null)
            {
                requestCustomerEndpoint_customerEndpoint_Address = cmdletContext.CustomerEndpoint_Address;
            }
            if (requestCustomerEndpoint_customerEndpoint_Address != null)
            {
                request.CustomerEndpoint.Address = requestCustomerEndpoint_customerEndpoint_Address;
                requestCustomerEndpointIsNull = false;
            }
            Amazon.Connect.EndpointType requestCustomerEndpoint_customerEndpoint_Type = null;
            if (cmdletContext.CustomerEndpoint_Type != null)
            {
                requestCustomerEndpoint_customerEndpoint_Type = cmdletContext.CustomerEndpoint_Type;
            }
            if (requestCustomerEndpoint_customerEndpoint_Type != null)
            {
                request.CustomerEndpoint.Type = requestCustomerEndpoint_customerEndpoint_Type;
                requestCustomerEndpointIsNull = false;
            }
             // determine if request.CustomerEndpoint should be set to null
            if (requestCustomerEndpointIsNull)
            {
                request.CustomerEndpoint = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate QueueInfo
            var requestQueueInfoIsNull = true;
            request.QueueInfo = new Amazon.Connect.Model.QueueInfoInput();
            System.String requestQueueInfo_queueInfo_Id = null;
            if (cmdletContext.QueueInfo_Id != null)
            {
                requestQueueInfo_queueInfo_Id = cmdletContext.QueueInfo_Id;
            }
            if (requestQueueInfo_queueInfo_Id != null)
            {
                request.QueueInfo.Id = requestQueueInfo_queueInfo_Id;
                requestQueueInfoIsNull = false;
            }
             // determine if request.QueueInfo should be set to null
            if (requestQueueInfoIsNull)
            {
                request.QueueInfo = null;
            }
            if (cmdletContext.Reference != null)
            {
                request.References = cmdletContext.Reference;
            }
            if (cmdletContext.SegmentAttribute != null)
            {
                request.SegmentAttributes = cmdletContext.SegmentAttribute;
            }
            
             // populate SystemEndpoint
            var requestSystemEndpointIsNull = true;
            request.SystemEndpoint = new Amazon.Connect.Model.Endpoint();
            System.String requestSystemEndpoint_systemEndpoint_Address = null;
            if (cmdletContext.SystemEndpoint_Address != null)
            {
                requestSystemEndpoint_systemEndpoint_Address = cmdletContext.SystemEndpoint_Address;
            }
            if (requestSystemEndpoint_systemEndpoint_Address != null)
            {
                request.SystemEndpoint.Address = requestSystemEndpoint_systemEndpoint_Address;
                requestSystemEndpointIsNull = false;
            }
            Amazon.Connect.EndpointType requestSystemEndpoint_systemEndpoint_Type = null;
            if (cmdletContext.SystemEndpoint_Type != null)
            {
                requestSystemEndpoint_systemEndpoint_Type = cmdletContext.SystemEndpoint_Type;
            }
            if (requestSystemEndpoint_systemEndpoint_Type != null)
            {
                request.SystemEndpoint.Type = requestSystemEndpoint_systemEndpoint_Type;
                requestSystemEndpointIsNull = false;
            }
             // determine if request.SystemEndpoint should be set to null
            if (requestSystemEndpointIsNull)
            {
                request.SystemEndpoint = null;
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
        
        private Amazon.Connect.Model.UpdateContactResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.UpdateContactRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "UpdateContact");
            try
            {
                #if DESKTOP
                return client.UpdateContact(request);
                #elif CORECLR
                return client.UpdateContactAsync(request).GetAwaiter().GetResult();
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
            public System.String ContactId { get; set; }
            public System.String CustomerEndpoint_Address { get; set; }
            public Amazon.Connect.EndpointType CustomerEndpoint_Type { get; set; }
            public System.String Description { get; set; }
            public System.String InstanceId { get; set; }
            public System.String Name { get; set; }
            public System.String QueueInfo_Id { get; set; }
            public Dictionary<System.String, Amazon.Connect.Model.Reference> Reference { get; set; }
            public Dictionary<System.String, Amazon.Connect.Model.SegmentAttributeValue> SegmentAttribute { get; set; }
            public System.String SystemEndpoint_Address { get; set; }
            public Amazon.Connect.EndpointType SystemEndpoint_Type { get; set; }
            public System.String UserInfo_UserId { get; set; }
            public System.Func<Amazon.Connect.Model.UpdateContactResponse, UpdateCONNContactCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
