/*******************************************************************************
 *  Copyright 2012-2024 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.IO;
using YamlDotNet.RepresentationModel;


namespace Amazon.PowerShell.Cmdlets.EKS
{
    /// <summary>
    /// Configures kubectl so that you can connect to an Amazon EKS cluster.
    /// </summary>
    [Cmdlet("Import", "EKSKubeConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("PSObject")]
    [AWSCmdlet("Calls the Amazon Elastic Container Service for Kubernetes DescribeAddonConfiguration API operation and creates/updates a kubeconfig file.")]
    [AWSCmdletOutput("PSObject",
        "This cmdlet returns an object containing the configured current-context and the path of the kubeconfig file. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ImportEKSKubeConfigCmdlet : AmazonEKSClientCmdlet, IExecutor
    {
        
        #region Parameter Name
        /// <summary>
        /// The name of the cluster for which to create a kubeconfig entry. 
        /// This cluster must exist in your account and in the specified or configured default region.
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

        #region Parameter KubeConfigPath
        /// <summary>
        /// Optionally specify a kubeconfig file to append with your configuration. By default,
        /// kubeconfig path (.kube/config) in your home directory.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KubeConfigPath { get; set; }
        #endregion

        #region Parameter RoleArn
        /// <summary>
        /// To assume a role for cluster authentication, specify an IAM role ARN with this option. 
        /// For example, if you created a cluster while assuming an IAM role, then you must also assume
        /// that role to connect to the cluster the first time.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion

        #region Parameter Alias
        /// <summary>
        /// Alias for the cluster context name. Defaults to match cluster ARN. 
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Alias { get; set; }
        #endregion

        #region Parameter UserAlias
        /// <summary>
        /// Alias for the generated user name. Defaults to match cluster ARN.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserAlias { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Name = this.Name;
            #if MODULAR
            if (Name == null && ParameterWasBound(nameof(Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif

            context.KubeConfigPath = this.KubeConfigPath;
            context.RoleArn = this.RoleArn;
            context.Alias = this.Alias;
            context.UserAlias = this.UserAlias;

            context.ProfileName = this.ProfileName;

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
            var request = new Amazon.EKS.Model.DescribeClusterRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                
                var newContext = KubeConfigHelper.UpdateCubeConfig(
                    response, 
                    cmdletContext.KubeConfigPath, 
                    cmdletContext.RoleArn, 
                    cmdletContext.ProfileName,
                    cmdletContext.Alias,
                    cmdletContext.UserAlias,
                    out var configPath);

                var contextObject = new PSObject();
                contextObject.Properties.Add(new PSNoteProperty("Context", newContext.Children[new YamlScalarNode("name")]));
                contextObject.Properties.Add(new PSNoteProperty("Path", configPath));

                output = new CmdletOutput
                {
                    PipelineOutput = contextObject,
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

        private DescribeClusterResponse CallAWSServiceOperation(IAmazonEKS client, DescribeClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Container Service for Kubernetes", "DescribeCluster");
            try
            {
                #if DESKTOP
                return client.DescribeCluster(request);
                #elif CORECLR
                return client.DescribeClusterAsync(request).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            
            public System.String KubeConfigPath { get; set; }

            public System.String RoleArn { get; set; }
            
            public System.String Alias { get; set; }
            
            public System.String UserAlias { get; set; }

            public System.String ProfileName { get; set; }

        }

    }
}
