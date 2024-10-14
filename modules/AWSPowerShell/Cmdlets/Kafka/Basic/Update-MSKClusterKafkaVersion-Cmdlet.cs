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
using Amazon.Kafka;
using Amazon.Kafka.Model;

namespace Amazon.PowerShell.Cmdlets.MSK
{
    /// <summary>
    /// Updates the Apache Kafka version for the cluster.
    /// </summary>
    [Cmdlet("Update", "MSKClusterKafkaVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kafka.Model.UpdateClusterKafkaVersionResponse")]
    [AWSCmdlet("Calls the Amazon Managed Streaming for Apache Kafka (MSK) UpdateClusterKafkaVersion API operation.", Operation = new[] {"UpdateClusterKafkaVersion"}, SelectReturnType = typeof(Amazon.Kafka.Model.UpdateClusterKafkaVersionResponse))]
    [AWSCmdletOutput("Amazon.Kafka.Model.UpdateClusterKafkaVersionResponse",
        "This cmdlet returns an Amazon.Kafka.Model.UpdateClusterKafkaVersionResponse object containing multiple properties."
    )]
    public partial class UpdateMSKClusterKafkaVersionCmdlet : AmazonKafkaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConfigurationInfo_Arn
        /// <summary>
        /// <para>
        /// <para>ARN of the configuration to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationInfo_Arn { get; set; }
        #endregion
        
        #region Parameter ClusterArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the cluster to be updated.</para>
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
        public System.String ClusterArn { get; set; }
        #endregion
        
        #region Parameter CurrentVersion
        /// <summary>
        /// <para>
        /// <para>Current cluster version.</para>
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
        public System.String CurrentVersion { get; set; }
        #endregion
        
        #region Parameter ConfigurationInfo_Revision
        /// <summary>
        /// <para>
        /// <para>The revision of the configuration to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? ConfigurationInfo_Revision { get; set; }
        #endregion
        
        #region Parameter TargetKafkaVersion
        /// <summary>
        /// <para>
        /// <para>Target Kafka version.</para>
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
        public System.String TargetKafkaVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kafka.Model.UpdateClusterKafkaVersionResponse).
        /// Specifying the name of a property of type Amazon.Kafka.Model.UpdateClusterKafkaVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ClusterArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ClusterArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ClusterArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MSKClusterKafkaVersion (UpdateClusterKafkaVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kafka.Model.UpdateClusterKafkaVersionResponse, UpdateMSKClusterKafkaVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ClusterArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClusterArn = this.ClusterArn;
            #if MODULAR
            if (this.ClusterArn == null && ParameterWasBound(nameof(this.ClusterArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConfigurationInfo_Arn = this.ConfigurationInfo_Arn;
            context.ConfigurationInfo_Revision = this.ConfigurationInfo_Revision;
            context.CurrentVersion = this.CurrentVersion;
            #if MODULAR
            if (this.CurrentVersion == null && ParameterWasBound(nameof(this.CurrentVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter CurrentVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetKafkaVersion = this.TargetKafkaVersion;
            #if MODULAR
            if (this.TargetKafkaVersion == null && ParameterWasBound(nameof(this.TargetKafkaVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetKafkaVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Kafka.Model.UpdateClusterKafkaVersionRequest();
            
            if (cmdletContext.ClusterArn != null)
            {
                request.ClusterArn = cmdletContext.ClusterArn;
            }
            
             // populate ConfigurationInfo
            var requestConfigurationInfoIsNull = true;
            request.ConfigurationInfo = new Amazon.Kafka.Model.ConfigurationInfo();
            System.String requestConfigurationInfo_configurationInfo_Arn = null;
            if (cmdletContext.ConfigurationInfo_Arn != null)
            {
                requestConfigurationInfo_configurationInfo_Arn = cmdletContext.ConfigurationInfo_Arn;
            }
            if (requestConfigurationInfo_configurationInfo_Arn != null)
            {
                request.ConfigurationInfo.Arn = requestConfigurationInfo_configurationInfo_Arn;
                requestConfigurationInfoIsNull = false;
            }
            System.Int64? requestConfigurationInfo_configurationInfo_Revision = null;
            if (cmdletContext.ConfigurationInfo_Revision != null)
            {
                requestConfigurationInfo_configurationInfo_Revision = cmdletContext.ConfigurationInfo_Revision.Value;
            }
            if (requestConfigurationInfo_configurationInfo_Revision != null)
            {
                request.ConfigurationInfo.Revision = requestConfigurationInfo_configurationInfo_Revision.Value;
                requestConfigurationInfoIsNull = false;
            }
             // determine if request.ConfigurationInfo should be set to null
            if (requestConfigurationInfoIsNull)
            {
                request.ConfigurationInfo = null;
            }
            if (cmdletContext.CurrentVersion != null)
            {
                request.CurrentVersion = cmdletContext.CurrentVersion;
            }
            if (cmdletContext.TargetKafkaVersion != null)
            {
                request.TargetKafkaVersion = cmdletContext.TargetKafkaVersion;
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
        
        private Amazon.Kafka.Model.UpdateClusterKafkaVersionResponse CallAWSServiceOperation(IAmazonKafka client, Amazon.Kafka.Model.UpdateClusterKafkaVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Streaming for Apache Kafka (MSK)", "UpdateClusterKafkaVersion");
            try
            {
                #if DESKTOP
                return client.UpdateClusterKafkaVersion(request);
                #elif CORECLR
                return client.UpdateClusterKafkaVersionAsync(request).GetAwaiter().GetResult();
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
            public System.String ClusterArn { get; set; }
            public System.String ConfigurationInfo_Arn { get; set; }
            public System.Int64? ConfigurationInfo_Revision { get; set; }
            public System.String CurrentVersion { get; set; }
            public System.String TargetKafkaVersion { get; set; }
            public System.Func<Amazon.Kafka.Model.UpdateClusterKafkaVersionResponse, UpdateMSKClusterKafkaVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
