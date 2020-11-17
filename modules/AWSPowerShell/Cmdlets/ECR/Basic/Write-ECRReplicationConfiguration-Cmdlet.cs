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
using Amazon.ECR;
using Amazon.ECR.Model;

namespace Amazon.PowerShell.Cmdlets.ECR
{
    /// <summary>
    /// Creates or updates the replication configuration for a registry. The existing replication
    /// configuration for a repository can be retrieved with the <a>DescribeRegistry</a> API
    /// action. The first time the PutReplicationConfiguration API is called, a service-linked
    /// IAM role is created in your account for the replication process. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonECR/latest/userguide/using-service-linked-roles.html">Using
    /// Service-Linked Roles for Amazon ECR</a> in the <i>Amazon Elastic Container Registry
    /// User Guide</i>.
    /// 
    ///  <note><para>
    /// When configuring cross-account replication, the destination account must grant the
    /// source account permission to replicate. This permission is controlled using a registry
    /// permissions policy. For more information, see <a>PutRegistryPolicy</a>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "ECRReplicationConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECR.Model.ReplicationConfiguration")]
    [AWSCmdlet("Calls the Amazon EC2 Container Registry PutReplicationConfiguration API operation.", Operation = new[] {"PutReplicationConfiguration"}, SelectReturnType = typeof(Amazon.ECR.Model.PutReplicationConfigurationResponse))]
    [AWSCmdletOutput("Amazon.ECR.Model.ReplicationConfiguration or Amazon.ECR.Model.PutReplicationConfigurationResponse",
        "This cmdlet returns an Amazon.ECR.Model.ReplicationConfiguration object.",
        "The service call response (type Amazon.ECR.Model.PutReplicationConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteECRReplicationConfigurationCmdlet : AmazonECRClientCmdlet, IExecutor
    {
        
        #region Parameter ReplicationConfiguration_Rule
        /// <summary>
        /// <para>
        /// <para>An array of objects representing the replication rules for a replication configuration.
        /// A replication configuration may contain only one replication rule but the rule may
        /// contain one or more replication destinations.</para>
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
        [Alias("ReplicationConfiguration_Rules")]
        public Amazon.ECR.Model.ReplicationRule[] ReplicationConfiguration_Rule { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReplicationConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECR.Model.PutReplicationConfigurationResponse).
        /// Specifying the name of a property of type Amazon.ECR.Model.PutReplicationConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReplicationConfiguration";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReplicationConfiguration_Rule), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-ECRReplicationConfiguration (PutReplicationConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECR.Model.PutReplicationConfigurationResponse, WriteECRReplicationConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ReplicationConfiguration_Rule != null)
            {
                context.ReplicationConfiguration_Rule = new List<Amazon.ECR.Model.ReplicationRule>(this.ReplicationConfiguration_Rule);
            }
            #if MODULAR
            if (this.ReplicationConfiguration_Rule == null && ParameterWasBound(nameof(this.ReplicationConfiguration_Rule)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicationConfiguration_Rule which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ECR.Model.PutReplicationConfigurationRequest();
            
            
             // populate ReplicationConfiguration
            var requestReplicationConfigurationIsNull = true;
            request.ReplicationConfiguration = new Amazon.ECR.Model.ReplicationConfiguration();
            List<Amazon.ECR.Model.ReplicationRule> requestReplicationConfiguration_replicationConfiguration_Rule = null;
            if (cmdletContext.ReplicationConfiguration_Rule != null)
            {
                requestReplicationConfiguration_replicationConfiguration_Rule = cmdletContext.ReplicationConfiguration_Rule;
            }
            if (requestReplicationConfiguration_replicationConfiguration_Rule != null)
            {
                request.ReplicationConfiguration.Rules = requestReplicationConfiguration_replicationConfiguration_Rule;
                requestReplicationConfigurationIsNull = false;
            }
             // determine if request.ReplicationConfiguration should be set to null
            if (requestReplicationConfigurationIsNull)
            {
                request.ReplicationConfiguration = null;
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
        
        private Amazon.ECR.Model.PutReplicationConfigurationResponse CallAWSServiceOperation(IAmazonECR client, Amazon.ECR.Model.PutReplicationConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Registry", "PutReplicationConfiguration");
            try
            {
                #if DESKTOP
                return client.PutReplicationConfiguration(request);
                #elif CORECLR
                return client.PutReplicationConfigurationAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.ECR.Model.ReplicationRule> ReplicationConfiguration_Rule { get; set; }
            public System.Func<Amazon.ECR.Model.PutReplicationConfigurationResponse, WriteECRReplicationConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReplicationConfiguration;
        }
        
    }
}
