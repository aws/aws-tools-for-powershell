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
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CGIP
{
    /// <summary>
    /// Returns the current provisioned limit for a specific API category.
    /// 
    ///  <note><para>
    /// Amazon Cognito evaluates Identity and Access Management (IAM) policies in requests
    /// for this API operation. For this operation, you must use IAM credentials to authorize
    /// requests, and you must grant yourself the corresponding IAM permission in a policy.
    /// </para><para><b>Learn more</b></para><ul><li><para><a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_aws-signing.html">Signing
    /// Amazon Web Services API Requests</a></para></li><li><para><a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pools-API-operations.html">Using
    /// the Amazon Cognito user pools API and user pool endpoints</a></para></li></ul></note>
    /// </summary>
    [Cmdlet("Get", "CGIPProvisionedLimit")]
    [OutputType("Amazon.CognitoIdentityProvider.Model.GetProvisionedLimitResponse")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider GetProvisionedLimit API operation.", Operation = new[] {"GetProvisionedLimit"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.GetProvisionedLimitResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.GetProvisionedLimitResponse",
        "This cmdlet returns an Amazon.CognitoIdentityProvider.Model.GetProvisionedLimitResponse object containing multiple properties."
    )]
    public partial class GetCGIPProvisionedLimitCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter LimitDefinition_Attribute
        /// <summary>
        /// <para>
        /// <para>The attributes that identify the specific limit. For API rate limits, specify the
        /// <c>Category</c> key with a value like <c>UserAuthentication</c> or <c>UserCreation</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("LimitDefinition_Attributes")]
        public System.Collections.Hashtable LimitDefinition_Attribute { get; set; }
        #endregion
        
        #region Parameter LimitDefinition_LimitClass
        /// <summary>
        /// <para>
        /// <para>The class of the limit. For API rate limits, this is <c>API_CATEGORY</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.LimitClass")]
        public Amazon.CognitoIdentityProvider.LimitClass LimitDefinition_LimitClass { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.GetProvisionedLimitResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentityProvider.Model.GetProvisionedLimitResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.GetProvisionedLimitResponse, GetCGIPProvisionedLimitCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.LimitDefinition_Attribute != null)
            {
                context.LimitDefinition_Attribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.LimitDefinition_Attribute.Keys)
                {
                    context.LimitDefinition_Attribute.Add((String)hashKey, (System.String)(this.LimitDefinition_Attribute[hashKey]));
                }
            }
            #if MODULAR
            if (this.LimitDefinition_Attribute == null && ParameterWasBound(nameof(this.LimitDefinition_Attribute)))
            {
                WriteWarning("You are passing $null as a value for parameter LimitDefinition_Attribute which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LimitDefinition_LimitClass = this.LimitDefinition_LimitClass;
            #if MODULAR
            if (this.LimitDefinition_LimitClass == null && ParameterWasBound(nameof(this.LimitDefinition_LimitClass)))
            {
                WriteWarning("You are passing $null as a value for parameter LimitDefinition_LimitClass which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CognitoIdentityProvider.Model.GetProvisionedLimitRequest();
            
            
             // populate LimitDefinition
            var requestLimitDefinitionIsNull = true;
            request.LimitDefinition = new Amazon.CognitoIdentityProvider.Model.LimitDefinitionType();
            Dictionary<System.String, System.String> requestLimitDefinition_limitDefinition_Attribute = null;
            if (cmdletContext.LimitDefinition_Attribute != null)
            {
                requestLimitDefinition_limitDefinition_Attribute = cmdletContext.LimitDefinition_Attribute;
            }
            if (requestLimitDefinition_limitDefinition_Attribute != null)
            {
                request.LimitDefinition.Attributes = requestLimitDefinition_limitDefinition_Attribute;
                requestLimitDefinitionIsNull = false;
            }
            Amazon.CognitoIdentityProvider.LimitClass requestLimitDefinition_limitDefinition_LimitClass = null;
            if (cmdletContext.LimitDefinition_LimitClass != null)
            {
                requestLimitDefinition_limitDefinition_LimitClass = cmdletContext.LimitDefinition_LimitClass;
            }
            if (requestLimitDefinition_limitDefinition_LimitClass != null)
            {
                request.LimitDefinition.LimitClass = requestLimitDefinition_limitDefinition_LimitClass;
                requestLimitDefinitionIsNull = false;
            }
             // determine if request.LimitDefinition should be set to null
            if (requestLimitDefinitionIsNull)
            {
                request.LimitDefinition = null;
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
        
        private Amazon.CognitoIdentityProvider.Model.GetProvisionedLimitResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.GetProvisionedLimitRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "GetProvisionedLimit");
            try
            {
                return client.GetProvisionedLimitAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> LimitDefinition_Attribute { get; set; }
            public Amazon.CognitoIdentityProvider.LimitClass LimitDefinition_LimitClass { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.GetProvisionedLimitResponse, GetCGIPProvisionedLimitCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
