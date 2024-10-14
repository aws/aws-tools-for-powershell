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
using Amazon.CustomerProfiles;
using Amazon.CustomerProfiles.Model;

namespace Amazon.PowerShell.Cmdlets.CPF
{
    /// <summary>
    /// Defines a ProfileObjectType.
    /// 
    ///  
    /// <para>
    /// To add or remove tags on an existing ObjectType, see <a href="https://docs.aws.amazon.com/customerprofiles/latest/APIReference/API_TagResource.html">
    /// TagResource</a>/<a href="https://docs.aws.amazon.com/customerprofiles/latest/APIReference/API_UntagResource.html">UntagResource</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CPFProfileObjectType", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CustomerProfiles.Model.PutProfileObjectTypeResponse")]
    [AWSCmdlet("Calls the Amazon Connect Customer Profiles PutProfileObjectType API operation.", Operation = new[] {"PutProfileObjectType"}, SelectReturnType = typeof(Amazon.CustomerProfiles.Model.PutProfileObjectTypeResponse))]
    [AWSCmdletOutput("Amazon.CustomerProfiles.Model.PutProfileObjectTypeResponse",
        "This cmdlet returns an Amazon.CustomerProfiles.Model.PutProfileObjectTypeResponse object containing multiple properties."
    )]
    public partial class WriteCPFProfileObjectTypeCmdlet : AmazonCustomerProfilesClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AllowProfileCreation
        /// <summary>
        /// <para>
        /// <para>Indicates whether a profile should be created when data is received if one doesn’t
        /// exist for an object of this type. The default is <c>FALSE</c>. If the AllowProfileCreation
        /// flag is set to <c>FALSE</c>, then the service tries to fetch a standard profile and
        /// associate this object with the profile. If it is set to <c>TRUE</c>, and if no match
        /// is found, then the service creates a new standard profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AllowProfileCreation { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Description of the profile object type.</para>
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
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The unique name of the domain.</para>
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter EncryptionKey
        /// <summary>
        /// <para>
        /// <para>The customer-provided key to encrypt the profile object that will be created in this
        /// profile object type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionKey { get; set; }
        #endregion
        
        #region Parameter ExpirationDay
        /// <summary>
        /// <para>
        /// <para>The number of days until the data in the object expires.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExpirationDays")]
        public System.Int32? ExpirationDay { get; set; }
        #endregion
        
        #region Parameter Field
        /// <summary>
        /// <para>
        /// <para>A map of the name and ObjectType field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Fields")]
        public System.Collections.Hashtable Field { get; set; }
        #endregion
        
        #region Parameter Key
        /// <summary>
        /// <para>
        /// <para>A list of unique keys that can be used to map data to the profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Keys")]
        public System.Collections.Hashtable Key { get; set; }
        #endregion
        
        #region Parameter MaxProfileObjectCount
        /// <summary>
        /// <para>
        /// <para>The amount of profile object max count assigned to the object type</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxProfileObjectCount { get; set; }
        #endregion
        
        #region Parameter ObjectTypeName
        /// <summary>
        /// <para>
        /// <para>The name of the profile object type.</para>
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
        public System.String ObjectTypeName { get; set; }
        #endregion
        
        #region Parameter SourceLastUpdatedTimestampFormat
        /// <summary>
        /// <para>
        /// <para>The format of your <c>sourceLastUpdatedTimestamp</c> that was previously set up. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceLastUpdatedTimestampFormat { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags used to organize, track, or control access for this resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter TemplateId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the object template. For some attributes in the request, the
        /// service will use the default value from the object template when TemplateId is present.
        /// If these attributes are present in the request, the service may return a <c>BadRequestException</c>.
        /// These attributes include: AllowProfileCreation, SourceLastUpdatedTimestampFormat,
        /// Fields, and Keys. For example, if AllowProfileCreation is set to true when TemplateId
        /// is set, the service may return a <c>BadRequestException</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CustomerProfiles.Model.PutProfileObjectTypeResponse).
        /// Specifying the name of a property of type Amazon.CustomerProfiles.Model.PutProfileObjectTypeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ObjectTypeName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ObjectTypeName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ObjectTypeName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ObjectTypeName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CPFProfileObjectType (PutProfileObjectType)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CustomerProfiles.Model.PutProfileObjectTypeResponse, WriteCPFProfileObjectTypeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ObjectTypeName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AllowProfileCreation = this.AllowProfileCreation;
            context.Description = this.Description;
            #if MODULAR
            if (this.Description == null && ParameterWasBound(nameof(this.Description)))
            {
                WriteWarning("You are passing $null as a value for parameter Description which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EncryptionKey = this.EncryptionKey;
            context.ExpirationDay = this.ExpirationDay;
            if (this.Field != null)
            {
                context.Field = new Dictionary<System.String, Amazon.CustomerProfiles.Model.ObjectTypeField>(StringComparer.Ordinal);
                foreach (var hashKey in this.Field.Keys)
                {
                    context.Field.Add((String)hashKey, (Amazon.CustomerProfiles.Model.ObjectTypeField)(this.Field[hashKey]));
                }
            }
            if (this.Key != null)
            {
                context.Key = new Dictionary<System.String, List<Amazon.CustomerProfiles.Model.ObjectTypeKey>>(StringComparer.Ordinal);
                foreach (var hashKey in this.Key.Keys)
                {
                    object hashValue = this.Key[hashKey];
                    if (hashValue == null)
                    {
                        context.Key.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<Amazon.CustomerProfiles.Model.ObjectTypeKey>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((Amazon.CustomerProfiles.Model.ObjectTypeKey)s);
                    }
                    context.Key.Add((String)hashKey, valueSet);
                }
            }
            context.MaxProfileObjectCount = this.MaxProfileObjectCount;
            context.ObjectTypeName = this.ObjectTypeName;
            #if MODULAR
            if (this.ObjectTypeName == null && ParameterWasBound(nameof(this.ObjectTypeName)))
            {
                WriteWarning("You are passing $null as a value for parameter ObjectTypeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceLastUpdatedTimestampFormat = this.SourceLastUpdatedTimestampFormat;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.TemplateId = this.TemplateId;
            
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
            var request = new Amazon.CustomerProfiles.Model.PutProfileObjectTypeRequest();
            
            if (cmdletContext.AllowProfileCreation != null)
            {
                request.AllowProfileCreation = cmdletContext.AllowProfileCreation.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.EncryptionKey != null)
            {
                request.EncryptionKey = cmdletContext.EncryptionKey;
            }
            if (cmdletContext.ExpirationDay != null)
            {
                request.ExpirationDays = cmdletContext.ExpirationDay.Value;
            }
            if (cmdletContext.Field != null)
            {
                request.Fields = cmdletContext.Field;
            }
            if (cmdletContext.Key != null)
            {
                request.Keys = cmdletContext.Key;
            }
            if (cmdletContext.MaxProfileObjectCount != null)
            {
                request.MaxProfileObjectCount = cmdletContext.MaxProfileObjectCount.Value;
            }
            if (cmdletContext.ObjectTypeName != null)
            {
                request.ObjectTypeName = cmdletContext.ObjectTypeName;
            }
            if (cmdletContext.SourceLastUpdatedTimestampFormat != null)
            {
                request.SourceLastUpdatedTimestampFormat = cmdletContext.SourceLastUpdatedTimestampFormat;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TemplateId != null)
            {
                request.TemplateId = cmdletContext.TemplateId;
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
        
        private Amazon.CustomerProfiles.Model.PutProfileObjectTypeResponse CallAWSServiceOperation(IAmazonCustomerProfiles client, Amazon.CustomerProfiles.Model.PutProfileObjectTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Customer Profiles", "PutProfileObjectType");
            try
            {
                #if DESKTOP
                return client.PutProfileObjectType(request);
                #elif CORECLR
                return client.PutProfileObjectTypeAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AllowProfileCreation { get; set; }
            public System.String Description { get; set; }
            public System.String DomainName { get; set; }
            public System.String EncryptionKey { get; set; }
            public System.Int32? ExpirationDay { get; set; }
            public Dictionary<System.String, Amazon.CustomerProfiles.Model.ObjectTypeField> Field { get; set; }
            public Dictionary<System.String, List<Amazon.CustomerProfiles.Model.ObjectTypeKey>> Key { get; set; }
            public System.Int32? MaxProfileObjectCount { get; set; }
            public System.String ObjectTypeName { get; set; }
            public System.String SourceLastUpdatedTimestampFormat { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String TemplateId { get; set; }
            public System.Func<Amazon.CustomerProfiles.Model.PutProfileObjectTypeResponse, WriteCPFProfileObjectTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
