/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.AppSync;
using Amazon.AppSync.Model;

namespace Amazon.PowerShell.Cmdlets.ASYN
{
    /// <summary>
    /// Updates a <code>GraphqlApi</code> object.
    /// </summary>
    [Cmdlet("Update", "ASYNGraphqlApi", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppSync.Model.GraphqlApi")]
    [AWSCmdlet("Calls the AWS AppSync UpdateGraphqlApi API operation.", Operation = new[] {"UpdateGraphqlApi"})]
    [AWSCmdletOutput("Amazon.AppSync.Model.GraphqlApi",
        "This cmdlet returns a GraphqlApi object.",
        "The service call response (type Amazon.AppSync.Model.UpdateGraphqlApiResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateASYNGraphqlApiCmdlet : AmazonAppSyncClientCmdlet, IExecutor
    {
        
        #region Parameter ApiId
        /// <summary>
        /// <para>
        /// <para>The API ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ApiId { get; set; }
        #endregion
        
        #region Parameter AuthenticationType
        /// <summary>
        /// <para>
        /// <para>The new authentication type for the <code>GraphqlApi</code> object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.AppSync.AuthenticationType")]
        public Amazon.AppSync.AuthenticationType AuthenticationType { get; set; }
        #endregion
        
        #region Parameter OpenIDConnectConfig_AuthTTL
        /// <summary>
        /// <para>
        /// <para>The number of milliseconds a token is valid after being authenticated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 OpenIDConnectConfig_AuthTTL { get; set; }
        #endregion
        
        #region Parameter OpenIDConnectConfig_ClientId
        /// <summary>
        /// <para>
        /// <para>The client identifier of the Relying party at the OpenID identity provider. This identifier
        /// is typically obtained when the Relying party is registered with the OpenID identity
        /// provider. You can specify a regular expression so the AWS AppSync can validate against
        /// multiple client identifiers at a time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String OpenIDConnectConfig_ClientId { get; set; }
        #endregion
        
        #region Parameter LogConfig_CloudWatchLogsRoleArn
        /// <summary>
        /// <para>
        /// <para>The service role that AWS AppSync will assume to publish to Amazon CloudWatch logs
        /// in your account. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LogConfig_CloudWatchLogsRoleArn { get; set; }
        #endregion
        
        #region Parameter LogConfig_FieldLogLevel
        /// <summary>
        /// <para>
        /// <para>The field logging level. Values can be NONE, ERROR, or ALL. </para><ul><li><para><b>NONE</b>: No field-level logs are captured.</para></li><li><para><b>ERROR</b>: Logs the following information only for the fields that are in error:</para><ul><li><para>The error section in the server response.</para></li><li><para>Field-level errors.</para></li><li><para>The generated request/response functions that got resolved for error fields.</para></li></ul></li><li><para><b>ALL</b>: The following information is logged for all fields in the query:</para><ul><li><para>Field-level tracing information.</para></li><li><para>The generated request/response functions that got resolved for each field.</para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.AppSync.FieldLogLevel")]
        public Amazon.AppSync.FieldLogLevel LogConfig_FieldLogLevel { get; set; }
        #endregion
        
        #region Parameter OpenIDConnectConfig_IatTTL
        /// <summary>
        /// <para>
        /// <para>The number of milliseconds a token is valid after being issued to a user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 OpenIDConnectConfig_IatTTL { get; set; }
        #endregion
        
        #region Parameter OpenIDConnectConfig_Issuer
        /// <summary>
        /// <para>
        /// <para>The issuer for the OpenID Connect configuration. The issuer returned by discovery
        /// must exactly match the value of <code>iss</code> in the ID token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String OpenIDConnectConfig_Issuer { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The new name for the <code>GraphqlApi</code> object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter UserPoolConfig
        /// <summary>
        /// <para>
        /// <para>The new Amazon Cognito user pool configuration for the <code>GraphqlApi</code> object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.AppSync.Model.UserPoolConfig UserPoolConfig { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ASYNGraphqlApi (UpdateGraphqlApi)"))
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
            
            context.ApiId = this.ApiId;
            context.AuthenticationType = this.AuthenticationType;
            context.LogConfig_CloudWatchLogsRoleArn = this.LogConfig_CloudWatchLogsRoleArn;
            context.LogConfig_FieldLogLevel = this.LogConfig_FieldLogLevel;
            context.Name = this.Name;
            if (ParameterWasBound("OpenIDConnectConfig_AuthTTL"))
                context.OpenIDConnectConfig_AuthTTL = this.OpenIDConnectConfig_AuthTTL;
            context.OpenIDConnectConfig_ClientId = this.OpenIDConnectConfig_ClientId;
            if (ParameterWasBound("OpenIDConnectConfig_IatTTL"))
                context.OpenIDConnectConfig_IatTTL = this.OpenIDConnectConfig_IatTTL;
            context.OpenIDConnectConfig_Issuer = this.OpenIDConnectConfig_Issuer;
            context.UserPoolConfig = this.UserPoolConfig;
            
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
            var request = new Amazon.AppSync.Model.UpdateGraphqlApiRequest();
            
            if (cmdletContext.ApiId != null)
            {
                request.ApiId = cmdletContext.ApiId;
            }
            if (cmdletContext.AuthenticationType != null)
            {
                request.AuthenticationType = cmdletContext.AuthenticationType;
            }
            
             // populate LogConfig
            bool requestLogConfigIsNull = true;
            request.LogConfig = new Amazon.AppSync.Model.LogConfig();
            System.String requestLogConfig_logConfig_CloudWatchLogsRoleArn = null;
            if (cmdletContext.LogConfig_CloudWatchLogsRoleArn != null)
            {
                requestLogConfig_logConfig_CloudWatchLogsRoleArn = cmdletContext.LogConfig_CloudWatchLogsRoleArn;
            }
            if (requestLogConfig_logConfig_CloudWatchLogsRoleArn != null)
            {
                request.LogConfig.CloudWatchLogsRoleArn = requestLogConfig_logConfig_CloudWatchLogsRoleArn;
                requestLogConfigIsNull = false;
            }
            Amazon.AppSync.FieldLogLevel requestLogConfig_logConfig_FieldLogLevel = null;
            if (cmdletContext.LogConfig_FieldLogLevel != null)
            {
                requestLogConfig_logConfig_FieldLogLevel = cmdletContext.LogConfig_FieldLogLevel;
            }
            if (requestLogConfig_logConfig_FieldLogLevel != null)
            {
                request.LogConfig.FieldLogLevel = requestLogConfig_logConfig_FieldLogLevel;
                requestLogConfigIsNull = false;
            }
             // determine if request.LogConfig should be set to null
            if (requestLogConfigIsNull)
            {
                request.LogConfig = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate OpenIDConnectConfig
            bool requestOpenIDConnectConfigIsNull = true;
            request.OpenIDConnectConfig = new Amazon.AppSync.Model.OpenIDConnectConfig();
            System.Int64? requestOpenIDConnectConfig_openIDConnectConfig_AuthTTL = null;
            if (cmdletContext.OpenIDConnectConfig_AuthTTL != null)
            {
                requestOpenIDConnectConfig_openIDConnectConfig_AuthTTL = cmdletContext.OpenIDConnectConfig_AuthTTL.Value;
            }
            if (requestOpenIDConnectConfig_openIDConnectConfig_AuthTTL != null)
            {
                request.OpenIDConnectConfig.AuthTTL = requestOpenIDConnectConfig_openIDConnectConfig_AuthTTL.Value;
                requestOpenIDConnectConfigIsNull = false;
            }
            System.String requestOpenIDConnectConfig_openIDConnectConfig_ClientId = null;
            if (cmdletContext.OpenIDConnectConfig_ClientId != null)
            {
                requestOpenIDConnectConfig_openIDConnectConfig_ClientId = cmdletContext.OpenIDConnectConfig_ClientId;
            }
            if (requestOpenIDConnectConfig_openIDConnectConfig_ClientId != null)
            {
                request.OpenIDConnectConfig.ClientId = requestOpenIDConnectConfig_openIDConnectConfig_ClientId;
                requestOpenIDConnectConfigIsNull = false;
            }
            System.Int64? requestOpenIDConnectConfig_openIDConnectConfig_IatTTL = null;
            if (cmdletContext.OpenIDConnectConfig_IatTTL != null)
            {
                requestOpenIDConnectConfig_openIDConnectConfig_IatTTL = cmdletContext.OpenIDConnectConfig_IatTTL.Value;
            }
            if (requestOpenIDConnectConfig_openIDConnectConfig_IatTTL != null)
            {
                request.OpenIDConnectConfig.IatTTL = requestOpenIDConnectConfig_openIDConnectConfig_IatTTL.Value;
                requestOpenIDConnectConfigIsNull = false;
            }
            System.String requestOpenIDConnectConfig_openIDConnectConfig_Issuer = null;
            if (cmdletContext.OpenIDConnectConfig_Issuer != null)
            {
                requestOpenIDConnectConfig_openIDConnectConfig_Issuer = cmdletContext.OpenIDConnectConfig_Issuer;
            }
            if (requestOpenIDConnectConfig_openIDConnectConfig_Issuer != null)
            {
                request.OpenIDConnectConfig.Issuer = requestOpenIDConnectConfig_openIDConnectConfig_Issuer;
                requestOpenIDConnectConfigIsNull = false;
            }
             // determine if request.OpenIDConnectConfig should be set to null
            if (requestOpenIDConnectConfigIsNull)
            {
                request.OpenIDConnectConfig = null;
            }
            if (cmdletContext.UserPoolConfig != null)
            {
                request.UserPoolConfig = cmdletContext.UserPoolConfig;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.GraphqlApi;
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
        
        private Amazon.AppSync.Model.UpdateGraphqlApiResponse CallAWSServiceOperation(IAmazonAppSync client, Amazon.AppSync.Model.UpdateGraphqlApiRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppSync", "UpdateGraphqlApi");
            try
            {
                #if DESKTOP
                return client.UpdateGraphqlApi(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateGraphqlApiAsync(request);
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
            public System.String ApiId { get; set; }
            public Amazon.AppSync.AuthenticationType AuthenticationType { get; set; }
            public System.String LogConfig_CloudWatchLogsRoleArn { get; set; }
            public Amazon.AppSync.FieldLogLevel LogConfig_FieldLogLevel { get; set; }
            public System.String Name { get; set; }
            public System.Int64? OpenIDConnectConfig_AuthTTL { get; set; }
            public System.String OpenIDConnectConfig_ClientId { get; set; }
            public System.Int64? OpenIDConnectConfig_IatTTL { get; set; }
            public System.String OpenIDConnectConfig_Issuer { get; set; }
            public Amazon.AppSync.Model.UserPoolConfig UserPoolConfig { get; set; }
        }
        
    }
}
