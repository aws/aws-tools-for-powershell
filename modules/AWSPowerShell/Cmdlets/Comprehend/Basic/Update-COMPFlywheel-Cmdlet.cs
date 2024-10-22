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
using Amazon.Comprehend;
using Amazon.Comprehend.Model;

namespace Amazon.PowerShell.Cmdlets.COMP
{
    /// <summary>
    /// Update the configuration information for an existing flywheel.
    /// </summary>
    [Cmdlet("Update", "COMPFlywheel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Comprehend.Model.FlywheelProperties")]
    [AWSCmdlet("Calls the Amazon Comprehend UpdateFlywheel API operation.", Operation = new[] {"UpdateFlywheel"}, SelectReturnType = typeof(Amazon.Comprehend.Model.UpdateFlywheelResponse))]
    [AWSCmdletOutput("Amazon.Comprehend.Model.FlywheelProperties or Amazon.Comprehend.Model.UpdateFlywheelResponse",
        "This cmdlet returns an Amazon.Comprehend.Model.FlywheelProperties object.",
        "The service call response (type Amazon.Comprehend.Model.UpdateFlywheelResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCOMPFlywheelCmdlet : AmazonComprehendClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ActiveModelArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Number (ARN) of the active model version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ActiveModelArn { get; set; }
        #endregion
        
        #region Parameter DataAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that grants Amazon Comprehend permission
        /// to access the flywheel data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter FlywheelArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Number (ARN) of the flywheel to update.</para>
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
        public System.String FlywheelArn { get; set; }
        #endregion
        
        #region Parameter DataSecurityConfig_ModelKmsKeyId
        /// <summary>
        /// <para>
        /// <para>ID for the KMS key that Amazon Comprehend uses to encrypt trained custom models. The
        /// ModelKmsKeyId can be either of the following formats:</para><ul><li><para>KMS Key ID: <c>"1234abcd-12ab-34cd-56ef-1234567890ab"</c></para></li><li><para>Amazon Resource Name (ARN) of a KMS Key: <c>"arn:aws:kms:us-west-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab"</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSecurityConfig_ModelKmsKeyId { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The ID number for a security group on an instance of your private VPC. Security groups
        /// on your VPC function serve as a virtual firewall to control inbound and outbound traffic
        /// and provides security for the resources that you’ll be accessing on the VPC. This
        /// ID number is preceded by "sg-", for instance: "sg-03b388029b0a285ea". For more information,
        /// see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/VPC_SecurityGroups.html">Security
        /// Groups for your VPC</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSecurityConfig_VpcConfig_SecurityGroupIds")]
        public System.String[] VpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VpcConfig_Subnet
        /// <summary>
        /// <para>
        /// <para>The ID for each subnet being used in your private VPC. This subnet is a subset of
        /// the a range of IPv4 addresses used by the VPC and is specific to a given availability
        /// zone in the VPC’s Region. This ID number is preceded by "subnet-", for instance: "subnet-04ccf456919e69055".
        /// For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/VPC_Subnets.html">VPCs
        /// and Subnets</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSecurityConfig_VpcConfig_Subnets")]
        public System.String[] VpcConfig_Subnet { get; set; }
        #endregion
        
        #region Parameter DataSecurityConfig_VolumeKmsKeyId
        /// <summary>
        /// <para>
        /// <para>ID for the KMS key that Amazon Comprehend uses to encrypt the volume.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSecurityConfig_VolumeKmsKeyId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FlywheelProperties'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Comprehend.Model.UpdateFlywheelResponse).
        /// Specifying the name of a property of type Amazon.Comprehend.Model.UpdateFlywheelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FlywheelProperties";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FlywheelArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-COMPFlywheel (UpdateFlywheel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Comprehend.Model.UpdateFlywheelResponse, UpdateCOMPFlywheelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActiveModelArn = this.ActiveModelArn;
            context.DataAccessRoleArn = this.DataAccessRoleArn;
            context.DataSecurityConfig_ModelKmsKeyId = this.DataSecurityConfig_ModelKmsKeyId;
            context.DataSecurityConfig_VolumeKmsKeyId = this.DataSecurityConfig_VolumeKmsKeyId;
            if (this.VpcConfig_SecurityGroupId != null)
            {
                context.VpcConfig_SecurityGroupId = new List<System.String>(this.VpcConfig_SecurityGroupId);
            }
            if (this.VpcConfig_Subnet != null)
            {
                context.VpcConfig_Subnet = new List<System.String>(this.VpcConfig_Subnet);
            }
            context.FlywheelArn = this.FlywheelArn;
            #if MODULAR
            if (this.FlywheelArn == null && ParameterWasBound(nameof(this.FlywheelArn)))
            {
                WriteWarning("You are passing $null as a value for parameter FlywheelArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Comprehend.Model.UpdateFlywheelRequest();
            
            if (cmdletContext.ActiveModelArn != null)
            {
                request.ActiveModelArn = cmdletContext.ActiveModelArn;
            }
            if (cmdletContext.DataAccessRoleArn != null)
            {
                request.DataAccessRoleArn = cmdletContext.DataAccessRoleArn;
            }
            
             // populate DataSecurityConfig
            var requestDataSecurityConfigIsNull = true;
            request.DataSecurityConfig = new Amazon.Comprehend.Model.UpdateDataSecurityConfig();
            System.String requestDataSecurityConfig_dataSecurityConfig_ModelKmsKeyId = null;
            if (cmdletContext.DataSecurityConfig_ModelKmsKeyId != null)
            {
                requestDataSecurityConfig_dataSecurityConfig_ModelKmsKeyId = cmdletContext.DataSecurityConfig_ModelKmsKeyId;
            }
            if (requestDataSecurityConfig_dataSecurityConfig_ModelKmsKeyId != null)
            {
                request.DataSecurityConfig.ModelKmsKeyId = requestDataSecurityConfig_dataSecurityConfig_ModelKmsKeyId;
                requestDataSecurityConfigIsNull = false;
            }
            System.String requestDataSecurityConfig_dataSecurityConfig_VolumeKmsKeyId = null;
            if (cmdletContext.DataSecurityConfig_VolumeKmsKeyId != null)
            {
                requestDataSecurityConfig_dataSecurityConfig_VolumeKmsKeyId = cmdletContext.DataSecurityConfig_VolumeKmsKeyId;
            }
            if (requestDataSecurityConfig_dataSecurityConfig_VolumeKmsKeyId != null)
            {
                request.DataSecurityConfig.VolumeKmsKeyId = requestDataSecurityConfig_dataSecurityConfig_VolumeKmsKeyId;
                requestDataSecurityConfigIsNull = false;
            }
            Amazon.Comprehend.Model.VpcConfig requestDataSecurityConfig_dataSecurityConfig_VpcConfig = null;
            
             // populate VpcConfig
            var requestDataSecurityConfig_dataSecurityConfig_VpcConfigIsNull = true;
            requestDataSecurityConfig_dataSecurityConfig_VpcConfig = new Amazon.Comprehend.Model.VpcConfig();
            List<System.String> requestDataSecurityConfig_dataSecurityConfig_VpcConfig_vpcConfig_SecurityGroupId = null;
            if (cmdletContext.VpcConfig_SecurityGroupId != null)
            {
                requestDataSecurityConfig_dataSecurityConfig_VpcConfig_vpcConfig_SecurityGroupId = cmdletContext.VpcConfig_SecurityGroupId;
            }
            if (requestDataSecurityConfig_dataSecurityConfig_VpcConfig_vpcConfig_SecurityGroupId != null)
            {
                requestDataSecurityConfig_dataSecurityConfig_VpcConfig.SecurityGroupIds = requestDataSecurityConfig_dataSecurityConfig_VpcConfig_vpcConfig_SecurityGroupId;
                requestDataSecurityConfig_dataSecurityConfig_VpcConfigIsNull = false;
            }
            List<System.String> requestDataSecurityConfig_dataSecurityConfig_VpcConfig_vpcConfig_Subnet = null;
            if (cmdletContext.VpcConfig_Subnet != null)
            {
                requestDataSecurityConfig_dataSecurityConfig_VpcConfig_vpcConfig_Subnet = cmdletContext.VpcConfig_Subnet;
            }
            if (requestDataSecurityConfig_dataSecurityConfig_VpcConfig_vpcConfig_Subnet != null)
            {
                requestDataSecurityConfig_dataSecurityConfig_VpcConfig.Subnets = requestDataSecurityConfig_dataSecurityConfig_VpcConfig_vpcConfig_Subnet;
                requestDataSecurityConfig_dataSecurityConfig_VpcConfigIsNull = false;
            }
             // determine if requestDataSecurityConfig_dataSecurityConfig_VpcConfig should be set to null
            if (requestDataSecurityConfig_dataSecurityConfig_VpcConfigIsNull)
            {
                requestDataSecurityConfig_dataSecurityConfig_VpcConfig = null;
            }
            if (requestDataSecurityConfig_dataSecurityConfig_VpcConfig != null)
            {
                request.DataSecurityConfig.VpcConfig = requestDataSecurityConfig_dataSecurityConfig_VpcConfig;
                requestDataSecurityConfigIsNull = false;
            }
             // determine if request.DataSecurityConfig should be set to null
            if (requestDataSecurityConfigIsNull)
            {
                request.DataSecurityConfig = null;
            }
            if (cmdletContext.FlywheelArn != null)
            {
                request.FlywheelArn = cmdletContext.FlywheelArn;
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
        
        private Amazon.Comprehend.Model.UpdateFlywheelResponse CallAWSServiceOperation(IAmazonComprehend client, Amazon.Comprehend.Model.UpdateFlywheelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Comprehend", "UpdateFlywheel");
            try
            {
                #if DESKTOP
                return client.UpdateFlywheel(request);
                #elif CORECLR
                return client.UpdateFlywheelAsync(request).GetAwaiter().GetResult();
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
            public System.String ActiveModelArn { get; set; }
            public System.String DataAccessRoleArn { get; set; }
            public System.String DataSecurityConfig_ModelKmsKeyId { get; set; }
            public System.String DataSecurityConfig_VolumeKmsKeyId { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_Subnet { get; set; }
            public System.String FlywheelArn { get; set; }
            public System.Func<Amazon.Comprehend.Model.UpdateFlywheelResponse, UpdateCOMPFlywheelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FlywheelProperties;
        }
        
    }
}
