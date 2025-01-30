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
using Amazon.CognitoIdentity;
using Amazon.CognitoIdentity.Model;

namespace Amazon.PowerShell.Cmdlets.CGI
{
    /// <summary>
    /// You can use this operation to use default (username and clientID) attribute or custom
    /// attribute mappings.
    /// </summary>
    [Cmdlet("Set", "CGIPrincipalTagAttributeMap", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentity.Model.SetPrincipalTagAttributeMapResponse")]
    [AWSCmdlet("Calls the Amazon Cognito Identity SetPrincipalTagAttributeMap API operation.", Operation = new[] {"SetPrincipalTagAttributeMap"}, SelectReturnType = typeof(Amazon.CognitoIdentity.Model.SetPrincipalTagAttributeMapResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentity.Model.SetPrincipalTagAttributeMapResponse",
        "This cmdlet returns an Amazon.CognitoIdentity.Model.SetPrincipalTagAttributeMapResponse object containing multiple properties."
    )]
    public partial class SetCGIPrincipalTagAttributeMapCmdlet : AmazonCognitoIdentityClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IdentityPoolId
        /// <summary>
        /// <para>
        /// <para>The ID of the Identity Pool you want to set attribute mappings for.</para>
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
        public System.String IdentityPoolId { get; set; }
        #endregion
        
        #region Parameter IdentityProviderName
        /// <summary>
        /// <para>
        /// <para>The provider name you want to use for attribute mappings.</para>
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
        public System.String IdentityProviderName { get; set; }
        #endregion
        
        #region Parameter PrincipalTag
        /// <summary>
        /// <para>
        /// <para>You can use this operation to add principal tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PrincipalTags")]
        public System.Collections.Hashtable PrincipalTag { get; set; }
        #endregion
        
        #region Parameter UseDefault
        /// <summary>
        /// <para>
        /// <para>You can use this operation to use default (username and clientID) attribute mappings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UseDefaults")]
        public System.Boolean? UseDefault { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentity.Model.SetPrincipalTagAttributeMapResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentity.Model.SetPrincipalTagAttributeMapResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the IdentityPoolId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^IdentityPoolId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^IdentityPoolId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IdentityPoolId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-CGIPrincipalTagAttributeMap (SetPrincipalTagAttributeMap)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentity.Model.SetPrincipalTagAttributeMapResponse, SetCGIPrincipalTagAttributeMapCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.IdentityPoolId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.IdentityPoolId = this.IdentityPoolId;
            #if MODULAR
            if (this.IdentityPoolId == null && ParameterWasBound(nameof(this.IdentityPoolId)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentityPoolId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdentityProviderName = this.IdentityProviderName;
            #if MODULAR
            if (this.IdentityProviderName == null && ParameterWasBound(nameof(this.IdentityProviderName)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentityProviderName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PrincipalTag != null)
            {
                context.PrincipalTag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.PrincipalTag.Keys)
                {
                    context.PrincipalTag.Add((String)hashKey, (System.String)(this.PrincipalTag[hashKey]));
                }
            }
            context.UseDefault = this.UseDefault;
            
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
            var request = new Amazon.CognitoIdentity.Model.SetPrincipalTagAttributeMapRequest();
            
            if (cmdletContext.IdentityPoolId != null)
            {
                request.IdentityPoolId = cmdletContext.IdentityPoolId;
            }
            if (cmdletContext.IdentityProviderName != null)
            {
                request.IdentityProviderName = cmdletContext.IdentityProviderName;
            }
            if (cmdletContext.PrincipalTag != null)
            {
                request.PrincipalTags = cmdletContext.PrincipalTag;
            }
            if (cmdletContext.UseDefault != null)
            {
                request.UseDefaults = cmdletContext.UseDefault.Value;
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
        
        private Amazon.CognitoIdentity.Model.SetPrincipalTagAttributeMapResponse CallAWSServiceOperation(IAmazonCognitoIdentity client, Amazon.CognitoIdentity.Model.SetPrincipalTagAttributeMapRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity", "SetPrincipalTagAttributeMap");
            try
            {
                #if DESKTOP
                return client.SetPrincipalTagAttributeMap(request);
                #elif CORECLR
                return client.SetPrincipalTagAttributeMapAsync(request).GetAwaiter().GetResult();
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
            public System.String IdentityPoolId { get; set; }
            public System.String IdentityProviderName { get; set; }
            public Dictionary<System.String, System.String> PrincipalTag { get; set; }
            public System.Boolean? UseDefault { get; set; }
            public System.Func<Amazon.CognitoIdentity.Model.SetPrincipalTagAttributeMapResponse, SetCGIPrincipalTagAttributeMapCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
