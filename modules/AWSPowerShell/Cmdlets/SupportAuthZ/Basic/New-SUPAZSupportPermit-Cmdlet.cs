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
using Amazon.SupportAuthZ;
using Amazon.SupportAuthZ.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SUPAZ
{
    /// <summary>
    /// Creates a support permit that authorizes an AWS support operator to perform specified
    /// actions on specified resources. The permit is cryptographically signed using a customer-managed
    /// AWS KMS key (ECC_NIST_P384, SIGN_VERIFY) to ensure non-repudiation.
    /// </summary>
    [Cmdlet("New", "SUPAZSupportPermit", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SupportAuthZ.Model.CreateSupportPermitResponse")]
    [AWSCmdlet("Calls the SupportAuthZ CreateSupportPermit API operation.", Operation = new[] {"CreateSupportPermit"}, SelectReturnType = typeof(Amazon.SupportAuthZ.Model.CreateSupportPermitResponse))]
    [AWSCmdletOutput("Amazon.SupportAuthZ.Model.CreateSupportPermitResponse",
        "This cmdlet returns an Amazon.SupportAuthZ.Model.CreateSupportPermitResponse object containing multiple properties."
    )]
    public partial class NewSUPAZSupportPermitCmdlet : AmazonSupportAuthZClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Permit_Actions_Action
        /// <summary>
        /// <para>
        /// <para>A list of specific support actions to authorize. Maximum of 10 actions.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Permit_Actions_Actions")]
        public System.String[] Permit_Actions_Action { get; set; }
        #endregion
        
        #region Parameter Permit_Actions_AllAction
        /// <summary>
        /// <para>
        /// <para>Authorizes all available support actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Permit_Actions_AllActions")]
        public Amazon.SupportAuthZ.Model.Unit Permit_Actions_AllAction { get; set; }
        #endregion
        
        #region Parameter Permit_Resources_AllResourcesInRegion
        /// <summary>
        /// <para>
        /// <para>Authorizes the support operator to act on all resources in the Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SupportAuthZ.Model.Unit Permit_Resources_AllResourcesInRegion { get; set; }
        #endregion
        
        #region Parameter Permit_Condition
        /// <summary>
        /// <para>
        /// <para>The time-window conditions that constrain when the permit is valid. Maximum of 2 conditions.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Permit_Conditions")]
        public Amazon.SupportAuthZ.Model.Condition[] Permit_Condition { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A human-readable description of why this permit is being created. Maximum length of
        /// 1024 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter SigningKeyInfo_KmsKey
        /// <summary>
        /// <para>
        /// <para>The ARN of the AWS KMS key used to sign the permit. The key must have key spec ECC_NIST_P384
        /// and key usage SIGN_VERIFY.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SigningKeyInfo_KmsKey { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A customer-chosen name for the support permit. Must be between 1 and 256 alphanumeric
        /// characters.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Permit_Resources_Resource
        /// <summary>
        /// <para>
        /// <para>A list of specific resource identifiers that the support operator is authorized to
        /// act upon. Maximum of 5 resources.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Permit_Resources_Resources")]
        public System.String[] Permit_Resources_Resource { get; set; }
        #endregion
        
        #region Parameter SupportCaseDisplayId
        /// <summary>
        /// <para>
        /// <para>The display identifier of the AWS Support case associated with this permit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SupportCaseDisplayId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to associate with the support permit on creation.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the operation completes no more
        /// than one time. If this token matches a previous request, the service returns the existing
        /// permit without creating a duplicate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SupportAuthZ.Model.CreateSupportPermitResponse).
        /// Specifying the name of a property of type Amazon.SupportAuthZ.Model.CreateSupportPermitResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SUPAZSupportPermit (CreateSupportPermit)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SupportAuthZ.Model.CreateSupportPermitResponse, NewSUPAZSupportPermitCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Permit_Actions_Action != null)
            {
                context.Permit_Actions_Action = new List<System.String>(this.Permit_Actions_Action);
            }
            context.Permit_Actions_AllAction = this.Permit_Actions_AllAction;
            if (this.Permit_Condition != null)
            {
                context.Permit_Condition = new List<Amazon.SupportAuthZ.Model.Condition>(this.Permit_Condition);
            }
            context.Permit_Resources_AllResourcesInRegion = this.Permit_Resources_AllResourcesInRegion;
            if (this.Permit_Resources_Resource != null)
            {
                context.Permit_Resources_Resource = new List<System.String>(this.Permit_Resources_Resource);
            }
            context.SigningKeyInfo_KmsKey = this.SigningKeyInfo_KmsKey;
            context.SupportCaseDisplayId = this.SupportCaseDisplayId;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
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
            var request = new Amazon.SupportAuthZ.Model.CreateSupportPermitRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate Permit
            var requestPermitIsNull = true;
            request.Permit = new Amazon.SupportAuthZ.Model.Permit();
            List<Amazon.SupportAuthZ.Model.Condition> requestPermit_permit_Condition = null;
            if (cmdletContext.Permit_Condition != null)
            {
                requestPermit_permit_Condition = cmdletContext.Permit_Condition;
            }
            if (requestPermit_permit_Condition != null)
            {
                request.Permit.Conditions = requestPermit_permit_Condition;
                requestPermitIsNull = false;
            }
            Amazon.SupportAuthZ.Model.ActionSet requestPermit_permit_Actions = null;
            
             // populate Actions
            var requestPermit_permit_ActionsIsNull = true;
            requestPermit_permit_Actions = new Amazon.SupportAuthZ.Model.ActionSet();
            List<System.String> requestPermit_permit_Actions_permit_Actions_Action = null;
            if (cmdletContext.Permit_Actions_Action != null)
            {
                requestPermit_permit_Actions_permit_Actions_Action = cmdletContext.Permit_Actions_Action;
            }
            if (requestPermit_permit_Actions_permit_Actions_Action != null)
            {
                requestPermit_permit_Actions.Actions = requestPermit_permit_Actions_permit_Actions_Action;
                requestPermit_permit_ActionsIsNull = false;
            }
            Amazon.SupportAuthZ.Model.Unit requestPermit_permit_Actions_permit_Actions_AllAction = null;
            if (cmdletContext.Permit_Actions_AllAction != null)
            {
                requestPermit_permit_Actions_permit_Actions_AllAction = cmdletContext.Permit_Actions_AllAction;
            }
            if (requestPermit_permit_Actions_permit_Actions_AllAction != null)
            {
                requestPermit_permit_Actions.AllActions = requestPermit_permit_Actions_permit_Actions_AllAction;
                requestPermit_permit_ActionsIsNull = false;
            }
             // determine if requestPermit_permit_Actions should be set to null
            if (requestPermit_permit_ActionsIsNull)
            {
                requestPermit_permit_Actions = null;
            }
            if (requestPermit_permit_Actions != null)
            {
                request.Permit.Actions = requestPermit_permit_Actions;
                requestPermitIsNull = false;
            }
            Amazon.SupportAuthZ.Model.ResourceSet requestPermit_permit_Resources = null;
            
             // populate Resources
            var requestPermit_permit_ResourcesIsNull = true;
            requestPermit_permit_Resources = new Amazon.SupportAuthZ.Model.ResourceSet();
            Amazon.SupportAuthZ.Model.Unit requestPermit_permit_Resources_permit_Resources_AllResourcesInRegion = null;
            if (cmdletContext.Permit_Resources_AllResourcesInRegion != null)
            {
                requestPermit_permit_Resources_permit_Resources_AllResourcesInRegion = cmdletContext.Permit_Resources_AllResourcesInRegion;
            }
            if (requestPermit_permit_Resources_permit_Resources_AllResourcesInRegion != null)
            {
                requestPermit_permit_Resources.AllResourcesInRegion = requestPermit_permit_Resources_permit_Resources_AllResourcesInRegion;
                requestPermit_permit_ResourcesIsNull = false;
            }
            List<System.String> requestPermit_permit_Resources_permit_Resources_Resource = null;
            if (cmdletContext.Permit_Resources_Resource != null)
            {
                requestPermit_permit_Resources_permit_Resources_Resource = cmdletContext.Permit_Resources_Resource;
            }
            if (requestPermit_permit_Resources_permit_Resources_Resource != null)
            {
                requestPermit_permit_Resources.Resources = requestPermit_permit_Resources_permit_Resources_Resource;
                requestPermit_permit_ResourcesIsNull = false;
            }
             // determine if requestPermit_permit_Resources should be set to null
            if (requestPermit_permit_ResourcesIsNull)
            {
                requestPermit_permit_Resources = null;
            }
            if (requestPermit_permit_Resources != null)
            {
                request.Permit.Resources = requestPermit_permit_Resources;
                requestPermitIsNull = false;
            }
             // determine if request.Permit should be set to null
            if (requestPermitIsNull)
            {
                request.Permit = null;
            }
            
             // populate SigningKeyInfo
            var requestSigningKeyInfoIsNull = true;
            request.SigningKeyInfo = new Amazon.SupportAuthZ.Model.SigningKeyInfo();
            System.String requestSigningKeyInfo_signingKeyInfo_KmsKey = null;
            if (cmdletContext.SigningKeyInfo_KmsKey != null)
            {
                requestSigningKeyInfo_signingKeyInfo_KmsKey = cmdletContext.SigningKeyInfo_KmsKey;
            }
            if (requestSigningKeyInfo_signingKeyInfo_KmsKey != null)
            {
                request.SigningKeyInfo.KmsKey = requestSigningKeyInfo_signingKeyInfo_KmsKey;
                requestSigningKeyInfoIsNull = false;
            }
             // determine if request.SigningKeyInfo should be set to null
            if (requestSigningKeyInfoIsNull)
            {
                request.SigningKeyInfo = null;
            }
            if (cmdletContext.SupportCaseDisplayId != null)
            {
                request.SupportCaseDisplayId = cmdletContext.SupportCaseDisplayId;
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
        
        private Amazon.SupportAuthZ.Model.CreateSupportPermitResponse CallAWSServiceOperation(IAmazonSupportAuthZ client, Amazon.SupportAuthZ.Model.CreateSupportPermitRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "SupportAuthZ", "CreateSupportPermit");
            try
            {
                return client.CreateSupportPermitAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public List<System.String> Permit_Actions_Action { get; set; }
            public Amazon.SupportAuthZ.Model.Unit Permit_Actions_AllAction { get; set; }
            public List<Amazon.SupportAuthZ.Model.Condition> Permit_Condition { get; set; }
            public Amazon.SupportAuthZ.Model.Unit Permit_Resources_AllResourcesInRegion { get; set; }
            public List<System.String> Permit_Resources_Resource { get; set; }
            public System.String SigningKeyInfo_KmsKey { get; set; }
            public System.String SupportCaseDisplayId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.SupportAuthZ.Model.CreateSupportPermitResponse, NewSUPAZSupportPermitCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
