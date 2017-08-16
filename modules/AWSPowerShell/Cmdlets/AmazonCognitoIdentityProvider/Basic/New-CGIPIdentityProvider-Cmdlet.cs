/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

namespace Amazon.PowerShell.Cmdlets.CGIP
{
    /// <summary>
    /// Creates an identity provider for a user pool.
    /// </summary>
    [Cmdlet("New", "CGIPIdentityProvider", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentityProvider.Model.IdentityProviderType")]
    [AWSCmdlet("Invokes the CreateIdentityProvider operation against Amazon Cognito Identity Provider.", Operation = new[] {"CreateIdentityProvider"})]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.IdentityProviderType",
        "This cmdlet returns a IdentityProviderType object.",
        "The service call response (type Amazon.CognitoIdentityProvider.Model.CreateIdentityProviderResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCGIPIdentityProviderCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        #region Parameter AttributeMapping
        /// <summary>
        /// <para>
        /// <para>A mapping of identity provider attributes to standard and custom user pool attributes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable AttributeMapping { get; set; }
        #endregion
        
        #region Parameter IdpIdentifier
        /// <summary>
        /// <para>
        /// <para>A list of identity provider identifiers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IdpIdentifiers")]
        public System.String[] IdpIdentifier { get; set; }
        #endregion
        
        #region Parameter ProviderDetail
        /// <summary>
        /// <para>
        /// <para>The identity provider details, such as <code>MetadataURL</code> and <code>MetadataFile</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ProviderDetails")]
        public System.Collections.Hashtable ProviderDetail { get; set; }
        #endregion
        
        #region Parameter ProviderName
        /// <summary>
        /// <para>
        /// <para>The identity provider name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ProviderName { get; set; }
        #endregion
        
        #region Parameter ProviderType
        /// <summary>
        /// <para>
        /// <para>The identity provider type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.IdentityProviderTypeType")]
        public Amazon.CognitoIdentityProvider.IdentityProviderTypeType ProviderType { get; set; }
        #endregion
        
        #region Parameter UserPoolId
        /// <summary>
        /// <para>
        /// <para>The user pool ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserPoolId { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ProviderName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CGIPIdentityProvider (CreateIdentityProvider)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.AttributeMapping != null)
            {
                context.AttributeMapping = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AttributeMapping.Keys)
                {
                    context.AttributeMapping.Add((String)hashKey, (String)(this.AttributeMapping[hashKey]));
                }
            }
            if (this.IdpIdentifier != null)
            {
                context.IdpIdentifiers = new List<System.String>(this.IdpIdentifier);
            }
            if (this.ProviderDetail != null)
            {
                context.ProviderDetails = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ProviderDetail.Keys)
                {
                    context.ProviderDetails.Add((String)hashKey, (String)(this.ProviderDetail[hashKey]));
                }
            }
            context.ProviderName = this.ProviderName;
            context.ProviderType = this.ProviderType;
            context.UserPoolId = this.UserPoolId;
            
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
            var request = new Amazon.CognitoIdentityProvider.Model.CreateIdentityProviderRequest();
            
            if (cmdletContext.AttributeMapping != null)
            {
                request.AttributeMapping = cmdletContext.AttributeMapping;
            }
            if (cmdletContext.IdpIdentifiers != null)
            {
                request.IdpIdentifiers = cmdletContext.IdpIdentifiers;
            }
            if (cmdletContext.ProviderDetails != null)
            {
                request.ProviderDetails = cmdletContext.ProviderDetails;
            }
            if (cmdletContext.ProviderName != null)
            {
                request.ProviderName = cmdletContext.ProviderName;
            }
            if (cmdletContext.ProviderType != null)
            {
                request.ProviderType = cmdletContext.ProviderType;
            }
            if (cmdletContext.UserPoolId != null)
            {
                request.UserPoolId = cmdletContext.UserPoolId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.IdentityProvider;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.CognitoIdentityProvider.Model.CreateIdentityProviderResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.CreateIdentityProviderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "CreateIdentityProvider");
            try
            {
                #if DESKTOP
                return client.CreateIdentityProvider(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateIdentityProviderAsync(request);
                return task.Result;
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
            public Dictionary<System.String, System.String> AttributeMapping { get; set; }
            public List<System.String> IdpIdentifiers { get; set; }
            public Dictionary<System.String, System.String> ProviderDetails { get; set; }
            public System.String ProviderName { get; set; }
            public Amazon.CognitoIdentityProvider.IdentityProviderTypeType ProviderType { get; set; }
            public System.String UserPoolId { get; set; }
        }
        
    }
}
