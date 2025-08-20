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
using Amazon.IdentityStore;
using Amazon.IdentityStore.Model;

namespace Amazon.PowerShell.Cmdlets.IDS
{
    /// <summary>
    /// Retrieves <c>GroupId</c> in an identity store.
    /// 
    ///  <note><para>
    /// If you have administrator access to a member account, you can use this API from the
    /// member account. Read about <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_manage_accounts_access.html">member
    /// accounts</a> in the <i>Organizations User Guide</i>. 
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "IDSGroupId")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Identity Store GetGroupId API operation.", Operation = new[] {"GetGroupId"}, SelectReturnType = typeof(Amazon.IdentityStore.Model.GetGroupIdResponse))]
    [AWSCmdletOutput("System.String or Amazon.IdentityStore.Model.GetGroupIdResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.IdentityStore.Model.GetGroupIdResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIDSGroupIdCmdlet : AmazonIdentityStoreClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter UniqueAttribute_AttributePath
        /// <summary>
        /// <para>
        /// <para>A string representation of the path to a given attribute or sub-attribute. Supports
        /// JMESPath.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AlternateIdentifier_UniqueAttribute_AttributePath")]
        public System.String UniqueAttribute_AttributePath { get; set; }
        #endregion
        
        #region Parameter UniqueAttribute_AttributeValue
        /// <summary>
        /// <para>
        /// <para>The value of the attribute. This is a <c>Document</c> type. This type is not supported
        /// by Java V1, Go V1, and older versions of the CLI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AlternateIdentifier_UniqueAttribute_AttributeValue")]
        public System.Management.Automation.PSObject UniqueAttribute_AttributeValue { get; set; }
        #endregion
        
        #region Parameter ExternalId_Id
        /// <summary>
        /// <para>
        /// <para>The identifier issued to this resource by an external identity provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AlternateIdentifier_ExternalId_Id")]
        public System.String ExternalId_Id { get; set; }
        #endregion
        
        #region Parameter IdentityStoreId
        /// <summary>
        /// <para>
        /// <para>The globally unique identifier for the identity store.</para>
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
        public System.String IdentityStoreId { get; set; }
        #endregion
        
        #region Parameter ExternalId_Issuer
        /// <summary>
        /// <para>
        /// <para>The issuer for an external identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AlternateIdentifier_ExternalId_Issuer")]
        public System.String ExternalId_Issuer { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GroupId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityStore.Model.GetGroupIdResponse).
        /// Specifying the name of a property of type Amazon.IdentityStore.Model.GetGroupIdResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GroupId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the IdentityStoreId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^IdentityStoreId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^IdentityStoreId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IdentityStore.Model.GetGroupIdResponse, GetIDSGroupIdCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.IdentityStoreId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ExternalId_Id = this.ExternalId_Id;
            context.ExternalId_Issuer = this.ExternalId_Issuer;
            context.UniqueAttribute_AttributePath = this.UniqueAttribute_AttributePath;
            context.UniqueAttribute_AttributeValue = this.UniqueAttribute_AttributeValue;
            context.IdentityStoreId = this.IdentityStoreId;
            #if MODULAR
            if (this.IdentityStoreId == null && ParameterWasBound(nameof(this.IdentityStoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentityStoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.IdentityStore.Model.GetGroupIdRequest();
            
            
             // populate AlternateIdentifier
            request.AlternateIdentifier = new Amazon.IdentityStore.Model.AlternateIdentifier();
            Amazon.IdentityStore.Model.ExternalId requestAlternateIdentifier_alternateIdentifier_ExternalId = null;
            
             // populate ExternalId
            var requestAlternateIdentifier_alternateIdentifier_ExternalIdIsNull = true;
            requestAlternateIdentifier_alternateIdentifier_ExternalId = new Amazon.IdentityStore.Model.ExternalId();
            System.String requestAlternateIdentifier_alternateIdentifier_ExternalId_externalId_Id = null;
            if (cmdletContext.ExternalId_Id != null)
            {
                requestAlternateIdentifier_alternateIdentifier_ExternalId_externalId_Id = cmdletContext.ExternalId_Id;
            }
            if (requestAlternateIdentifier_alternateIdentifier_ExternalId_externalId_Id != null)
            {
                requestAlternateIdentifier_alternateIdentifier_ExternalId.Id = requestAlternateIdentifier_alternateIdentifier_ExternalId_externalId_Id;
                requestAlternateIdentifier_alternateIdentifier_ExternalIdIsNull = false;
            }
            System.String requestAlternateIdentifier_alternateIdentifier_ExternalId_externalId_Issuer = null;
            if (cmdletContext.ExternalId_Issuer != null)
            {
                requestAlternateIdentifier_alternateIdentifier_ExternalId_externalId_Issuer = cmdletContext.ExternalId_Issuer;
            }
            if (requestAlternateIdentifier_alternateIdentifier_ExternalId_externalId_Issuer != null)
            {
                requestAlternateIdentifier_alternateIdentifier_ExternalId.Issuer = requestAlternateIdentifier_alternateIdentifier_ExternalId_externalId_Issuer;
                requestAlternateIdentifier_alternateIdentifier_ExternalIdIsNull = false;
            }
             // determine if requestAlternateIdentifier_alternateIdentifier_ExternalId should be set to null
            if (requestAlternateIdentifier_alternateIdentifier_ExternalIdIsNull)
            {
                requestAlternateIdentifier_alternateIdentifier_ExternalId = null;
            }
            if (requestAlternateIdentifier_alternateIdentifier_ExternalId != null)
            {
                request.AlternateIdentifier.ExternalId = requestAlternateIdentifier_alternateIdentifier_ExternalId;
            }
            Amazon.IdentityStore.Model.UniqueAttribute requestAlternateIdentifier_alternateIdentifier_UniqueAttribute = null;
            
             // populate UniqueAttribute
            var requestAlternateIdentifier_alternateIdentifier_UniqueAttributeIsNull = true;
            requestAlternateIdentifier_alternateIdentifier_UniqueAttribute = new Amazon.IdentityStore.Model.UniqueAttribute();
            System.String requestAlternateIdentifier_alternateIdentifier_UniqueAttribute_uniqueAttribute_AttributePath = null;
            if (cmdletContext.UniqueAttribute_AttributePath != null)
            {
                requestAlternateIdentifier_alternateIdentifier_UniqueAttribute_uniqueAttribute_AttributePath = cmdletContext.UniqueAttribute_AttributePath;
            }
            if (requestAlternateIdentifier_alternateIdentifier_UniqueAttribute_uniqueAttribute_AttributePath != null)
            {
                requestAlternateIdentifier_alternateIdentifier_UniqueAttribute.AttributePath = requestAlternateIdentifier_alternateIdentifier_UniqueAttribute_uniqueAttribute_AttributePath;
                requestAlternateIdentifier_alternateIdentifier_UniqueAttributeIsNull = false;
            }
            Amazon.Runtime.Documents.Document? requestAlternateIdentifier_alternateIdentifier_UniqueAttribute_uniqueAttribute_AttributeValue = null;
            if (cmdletContext.UniqueAttribute_AttributeValue != null)
            {
                requestAlternateIdentifier_alternateIdentifier_UniqueAttribute_uniqueAttribute_AttributeValue = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.UniqueAttribute_AttributeValue);
            }
            if (requestAlternateIdentifier_alternateIdentifier_UniqueAttribute_uniqueAttribute_AttributeValue != null)
            {
                requestAlternateIdentifier_alternateIdentifier_UniqueAttribute.AttributeValue = requestAlternateIdentifier_alternateIdentifier_UniqueAttribute_uniqueAttribute_AttributeValue.Value;
                requestAlternateIdentifier_alternateIdentifier_UniqueAttributeIsNull = false;
            }
             // determine if requestAlternateIdentifier_alternateIdentifier_UniqueAttribute should be set to null
            if (requestAlternateIdentifier_alternateIdentifier_UniqueAttributeIsNull)
            {
                requestAlternateIdentifier_alternateIdentifier_UniqueAttribute = null;
            }
            if (requestAlternateIdentifier_alternateIdentifier_UniqueAttribute != null)
            {
                request.AlternateIdentifier.UniqueAttribute = requestAlternateIdentifier_alternateIdentifier_UniqueAttribute;
            }
            if (cmdletContext.IdentityStoreId != null)
            {
                request.IdentityStoreId = cmdletContext.IdentityStoreId;
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
        
        private Amazon.IdentityStore.Model.GetGroupIdResponse CallAWSServiceOperation(IAmazonIdentityStore client, Amazon.IdentityStore.Model.GetGroupIdRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity Store", "GetGroupId");
            try
            {
                #if DESKTOP
                return client.GetGroupId(request);
                #elif CORECLR
                return client.GetGroupIdAsync(request).GetAwaiter().GetResult();
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
            public System.String ExternalId_Id { get; set; }
            public System.String ExternalId_Issuer { get; set; }
            public System.String UniqueAttribute_AttributePath { get; set; }
            public System.Management.Automation.PSObject UniqueAttribute_AttributeValue { get; set; }
            public System.String IdentityStoreId { get; set; }
            public System.Func<Amazon.IdentityStore.Model.GetGroupIdResponse, GetIDSGroupIdCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GroupId;
        }
        
    }
}
