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
using Amazon.EKS;
using Amazon.EKS.Model;

namespace Amazon.PowerShell.Cmdlets.EKS
{
    /// <summary>
    /// Describes an identity provider configuration.
    /// </summary>
    [Cmdlet("Get", "EKSIdentityProviderConfig")]
    [OutputType("Amazon.EKS.Model.IdentityProviderConfigResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Container Service for Kubernetes DescribeIdentityProviderConfig API operation.", Operation = new[] {"DescribeIdentityProviderConfig"}, SelectReturnType = typeof(Amazon.EKS.Model.DescribeIdentityProviderConfigResponse))]
    [AWSCmdletOutput("Amazon.EKS.Model.IdentityProviderConfigResponse or Amazon.EKS.Model.DescribeIdentityProviderConfigResponse",
        "This cmdlet returns an Amazon.EKS.Model.IdentityProviderConfigResponse object.",
        "The service call response (type Amazon.EKS.Model.DescribeIdentityProviderConfigResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEKSIdentityProviderConfigCmdlet : AmazonEKSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClusterName
        /// <summary>
        /// <para>
        /// <para>The name of your cluster.</para>
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
        public System.String ClusterName { get; set; }
        #endregion
        
        #region Parameter IdentityProviderConfig_Name
        /// <summary>
        /// <para>
        /// <para>The name of the identity provider configuration.</para>
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
        public System.String IdentityProviderConfig_Name { get; set; }
        #endregion
        
        #region Parameter IdentityProviderConfig_Type
        /// <summary>
        /// <para>
        /// <para>The type of the identity provider configuration. The only type available is <c>oidc</c>.</para>
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
        public System.String IdentityProviderConfig_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IdentityProviderConfig'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EKS.Model.DescribeIdentityProviderConfigResponse).
        /// Specifying the name of a property of type Amazon.EKS.Model.DescribeIdentityProviderConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IdentityProviderConfig";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EKS.Model.DescribeIdentityProviderConfigResponse, GetEKSIdentityProviderConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClusterName = this.ClusterName;
            #if MODULAR
            if (this.ClusterName == null && ParameterWasBound(nameof(this.ClusterName)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdentityProviderConfig_Name = this.IdentityProviderConfig_Name;
            #if MODULAR
            if (this.IdentityProviderConfig_Name == null && ParameterWasBound(nameof(this.IdentityProviderConfig_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentityProviderConfig_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdentityProviderConfig_Type = this.IdentityProviderConfig_Type;
            #if MODULAR
            if (this.IdentityProviderConfig_Type == null && ParameterWasBound(nameof(this.IdentityProviderConfig_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentityProviderConfig_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EKS.Model.DescribeIdentityProviderConfigRequest();
            
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterName = cmdletContext.ClusterName;
            }
            
             // populate IdentityProviderConfig
            var requestIdentityProviderConfigIsNull = true;
            request.IdentityProviderConfig = new Amazon.EKS.Model.IdentityProviderConfig();
            System.String requestIdentityProviderConfig_identityProviderConfig_Name = null;
            if (cmdletContext.IdentityProviderConfig_Name != null)
            {
                requestIdentityProviderConfig_identityProviderConfig_Name = cmdletContext.IdentityProviderConfig_Name;
            }
            if (requestIdentityProviderConfig_identityProviderConfig_Name != null)
            {
                request.IdentityProviderConfig.Name = requestIdentityProviderConfig_identityProviderConfig_Name;
                requestIdentityProviderConfigIsNull = false;
            }
            System.String requestIdentityProviderConfig_identityProviderConfig_Type = null;
            if (cmdletContext.IdentityProviderConfig_Type != null)
            {
                requestIdentityProviderConfig_identityProviderConfig_Type = cmdletContext.IdentityProviderConfig_Type;
            }
            if (requestIdentityProviderConfig_identityProviderConfig_Type != null)
            {
                request.IdentityProviderConfig.Type = requestIdentityProviderConfig_identityProviderConfig_Type;
                requestIdentityProviderConfigIsNull = false;
            }
             // determine if request.IdentityProviderConfig should be set to null
            if (requestIdentityProviderConfigIsNull)
            {
                request.IdentityProviderConfig = null;
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
        
        private Amazon.EKS.Model.DescribeIdentityProviderConfigResponse CallAWSServiceOperation(IAmazonEKS client, Amazon.EKS.Model.DescribeIdentityProviderConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Container Service for Kubernetes", "DescribeIdentityProviderConfig");
            try
            {
                #if DESKTOP
                return client.DescribeIdentityProviderConfig(request);
                #elif CORECLR
                return client.DescribeIdentityProviderConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String ClusterName { get; set; }
            public System.String IdentityProviderConfig_Name { get; set; }
            public System.String IdentityProviderConfig_Type { get; set; }
            public System.Func<Amazon.EKS.Model.DescribeIdentityProviderConfigResponse, GetEKSIdentityProviderConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IdentityProviderConfig;
        }
        
    }
}
