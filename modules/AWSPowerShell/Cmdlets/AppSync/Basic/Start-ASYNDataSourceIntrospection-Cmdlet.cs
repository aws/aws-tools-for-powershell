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
using Amazon.AppSync;
using Amazon.AppSync.Model;

namespace Amazon.PowerShell.Cmdlets.ASYN
{
    /// <summary>
    /// Creates a new introspection. Returns the <c>introspectionId</c> of the new introspection
    /// after its creation.
    /// </summary>
    [Cmdlet("Start", "ASYNDataSourceIntrospection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppSync.Model.StartDataSourceIntrospectionResponse")]
    [AWSCmdlet("Calls the AWS AppSync StartDataSourceIntrospection API operation.", Operation = new[] {"StartDataSourceIntrospection"}, SelectReturnType = typeof(Amazon.AppSync.Model.StartDataSourceIntrospectionResponse))]
    [AWSCmdletOutput("Amazon.AppSync.Model.StartDataSourceIntrospectionResponse",
        "This cmdlet returns an Amazon.AppSync.Model.StartDataSourceIntrospectionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartASYNDataSourceIntrospectionCmdlet : AmazonAppSyncClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RdsDataApiConfig_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the database in the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RdsDataApiConfig_DatabaseName { get; set; }
        #endregion
        
        #region Parameter RdsDataApiConfig_ResourceArn
        /// <summary>
        /// <para>
        /// <para>The resource ARN of the RDS cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RdsDataApiConfig_ResourceArn { get; set; }
        #endregion
        
        #region Parameter RdsDataApiConfig_SecretArn
        /// <summary>
        /// <para>
        /// <para>The secret's ARN that was obtained from Secrets Manager. A secret consists of secret
        /// information, the secret value, plus metadata about the secret. A secret value can
        /// be a string or binary. It typically includes the ARN, secret name and description,
        /// policies, tags, encryption key from the Key Management Service, and key rotation data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RdsDataApiConfig_SecretArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppSync.Model.StartDataSourceIntrospectionResponse).
        /// Specifying the name of a property of type Amazon.AppSync.Model.StartDataSourceIntrospectionResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-ASYNDataSourceIntrospection (StartDataSourceIntrospection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppSync.Model.StartDataSourceIntrospectionResponse, StartASYNDataSourceIntrospectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.RdsDataApiConfig_DatabaseName = this.RdsDataApiConfig_DatabaseName;
            context.RdsDataApiConfig_ResourceArn = this.RdsDataApiConfig_ResourceArn;
            context.RdsDataApiConfig_SecretArn = this.RdsDataApiConfig_SecretArn;
            
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
            var request = new Amazon.AppSync.Model.StartDataSourceIntrospectionRequest();
            
            
             // populate RdsDataApiConfig
            var requestRdsDataApiConfigIsNull = true;
            request.RdsDataApiConfig = new Amazon.AppSync.Model.RdsDataApiConfig();
            System.String requestRdsDataApiConfig_rdsDataApiConfig_DatabaseName = null;
            if (cmdletContext.RdsDataApiConfig_DatabaseName != null)
            {
                requestRdsDataApiConfig_rdsDataApiConfig_DatabaseName = cmdletContext.RdsDataApiConfig_DatabaseName;
            }
            if (requestRdsDataApiConfig_rdsDataApiConfig_DatabaseName != null)
            {
                request.RdsDataApiConfig.DatabaseName = requestRdsDataApiConfig_rdsDataApiConfig_DatabaseName;
                requestRdsDataApiConfigIsNull = false;
            }
            System.String requestRdsDataApiConfig_rdsDataApiConfig_ResourceArn = null;
            if (cmdletContext.RdsDataApiConfig_ResourceArn != null)
            {
                requestRdsDataApiConfig_rdsDataApiConfig_ResourceArn = cmdletContext.RdsDataApiConfig_ResourceArn;
            }
            if (requestRdsDataApiConfig_rdsDataApiConfig_ResourceArn != null)
            {
                request.RdsDataApiConfig.ResourceArn = requestRdsDataApiConfig_rdsDataApiConfig_ResourceArn;
                requestRdsDataApiConfigIsNull = false;
            }
            System.String requestRdsDataApiConfig_rdsDataApiConfig_SecretArn = null;
            if (cmdletContext.RdsDataApiConfig_SecretArn != null)
            {
                requestRdsDataApiConfig_rdsDataApiConfig_SecretArn = cmdletContext.RdsDataApiConfig_SecretArn;
            }
            if (requestRdsDataApiConfig_rdsDataApiConfig_SecretArn != null)
            {
                request.RdsDataApiConfig.SecretArn = requestRdsDataApiConfig_rdsDataApiConfig_SecretArn;
                requestRdsDataApiConfigIsNull = false;
            }
             // determine if request.RdsDataApiConfig should be set to null
            if (requestRdsDataApiConfigIsNull)
            {
                request.RdsDataApiConfig = null;
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
        
        private Amazon.AppSync.Model.StartDataSourceIntrospectionResponse CallAWSServiceOperation(IAmazonAppSync client, Amazon.AppSync.Model.StartDataSourceIntrospectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppSync", "StartDataSourceIntrospection");
            try
            {
                #if DESKTOP
                return client.StartDataSourceIntrospection(request);
                #elif CORECLR
                return client.StartDataSourceIntrospectionAsync(request).GetAwaiter().GetResult();
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
            public System.String RdsDataApiConfig_DatabaseName { get; set; }
            public System.String RdsDataApiConfig_ResourceArn { get; set; }
            public System.String RdsDataApiConfig_SecretArn { get; set; }
            public System.Func<Amazon.AppSync.Model.StartDataSourceIntrospectionResponse, StartASYNDataSourceIntrospectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
