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
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;

namespace Amazon.PowerShell.Cmdlets.DMS
{
    /// <summary>
    /// Modifies the specified instance profile using the provided parameters.
    /// 
    ///  <note><para>
    /// All migration projects associated with the instance profile must be deleted or modified
    /// before you can modify the instance profile.
    /// </para></note>
    /// </summary>
    [Cmdlet("Edit", "DMSInstanceProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DatabaseMigrationService.Model.InstanceProfile")]
    [AWSCmdlet("Calls the AWS Database Migration Service ModifyInstanceProfile API operation.", Operation = new[] {"ModifyInstanceProfile"}, SelectReturnType = typeof(Amazon.DatabaseMigrationService.Model.ModifyInstanceProfileResponse))]
    [AWSCmdletOutput("Amazon.DatabaseMigrationService.Model.InstanceProfile or Amazon.DatabaseMigrationService.Model.ModifyInstanceProfileResponse",
        "This cmdlet returns an Amazon.DatabaseMigrationService.Model.InstanceProfile object.",
        "The service call response (type Amazon.DatabaseMigrationService.Model.ModifyInstanceProfileResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditDMSInstanceProfileCmdlet : AmazonDatabaseMigrationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone where the instance profile runs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A user-friendly description for the instance profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter InstanceProfileIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the instance profile. Identifiers must begin with a letter and must
        /// contain only ASCII letters, digits, and hyphens. They can't end with a hyphen, or
        /// contain two consecutive hyphens.</para>
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
        public System.String InstanceProfileIdentifier { get; set; }
        #endregion
        
        #region Parameter InstanceProfileName
        /// <summary>
        /// <para>
        /// <para>A user-friendly name for the instance profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceProfileName { get; set; }
        #endregion
        
        #region Parameter KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the KMS key that is used to encrypt the connection
        /// parameters for the instance profile.</para><para>If you don't specify a value for the <c>KmsKeyArn</c> parameter, then DMS uses your
        /// default encryption key.</para><para>KMS creates the default encryption key for your Amazon Web Services account. Your
        /// Amazon Web Services account has a different default encryption key for each Amazon
        /// Web Services Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter NetworkType
        /// <summary>
        /// <para>
        /// <para>Specifies the network type for the instance profile. A value of <c>IPV4</c> represents
        /// an instance profile with IPv4 network type and only supports IPv4 addressing. A value
        /// of <c>IPV6</c> represents an instance profile with IPv6 network type and only supports
        /// IPv6 addressing. A value of <c>DUAL</c> represents an instance profile with dual network
        /// type that supports IPv4 and IPv6 addressing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NetworkType { get; set; }
        #endregion
        
        #region Parameter PubliclyAccessible
        /// <summary>
        /// <para>
        /// <para>Specifies the accessibility options for the instance profile. A value of <c>true</c>
        /// represents an instance profile with a public IP address. A value of <c>false</c> represents
        /// an instance profile with a private IP address. The default value is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PubliclyAccessible { get; set; }
        #endregion
        
        #region Parameter SubnetGroupIdentifier
        /// <summary>
        /// <para>
        /// <para>A subnet group to associate with the instance profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubnetGroupIdentifier { get; set; }
        #endregion
        
        #region Parameter VpcSecurityGroup
        /// <summary>
        /// <para>
        /// <para>Specifies the VPC security groups to be used with the instance profile. The VPC security
        /// group must work with the VPC containing the instance profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcSecurityGroups")]
        public System.String[] VpcSecurityGroup { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InstanceProfile'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DatabaseMigrationService.Model.ModifyInstanceProfileResponse).
        /// Specifying the name of a property of type Amazon.DatabaseMigrationService.Model.ModifyInstanceProfileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InstanceProfile";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceProfileIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceProfileIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceProfileIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceProfileIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-DMSInstanceProfile (ModifyInstanceProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DatabaseMigrationService.Model.ModifyInstanceProfileResponse, EditDMSInstanceProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceProfileIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AvailabilityZone = this.AvailabilityZone;
            context.Description = this.Description;
            context.InstanceProfileIdentifier = this.InstanceProfileIdentifier;
            #if MODULAR
            if (this.InstanceProfileIdentifier == null && ParameterWasBound(nameof(this.InstanceProfileIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceProfileIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceProfileName = this.InstanceProfileName;
            context.KmsKeyArn = this.KmsKeyArn;
            context.NetworkType = this.NetworkType;
            context.PubliclyAccessible = this.PubliclyAccessible;
            context.SubnetGroupIdentifier = this.SubnetGroupIdentifier;
            if (this.VpcSecurityGroup != null)
            {
                context.VpcSecurityGroup = new List<System.String>(this.VpcSecurityGroup);
            }
            
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
            var request = new Amazon.DatabaseMigrationService.Model.ModifyInstanceProfileRequest();
            
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.InstanceProfileIdentifier != null)
            {
                request.InstanceProfileIdentifier = cmdletContext.InstanceProfileIdentifier;
            }
            if (cmdletContext.InstanceProfileName != null)
            {
                request.InstanceProfileName = cmdletContext.InstanceProfileName;
            }
            if (cmdletContext.KmsKeyArn != null)
            {
                request.KmsKeyArn = cmdletContext.KmsKeyArn;
            }
            if (cmdletContext.NetworkType != null)
            {
                request.NetworkType = cmdletContext.NetworkType;
            }
            if (cmdletContext.PubliclyAccessible != null)
            {
                request.PubliclyAccessible = cmdletContext.PubliclyAccessible.Value;
            }
            if (cmdletContext.SubnetGroupIdentifier != null)
            {
                request.SubnetGroupIdentifier = cmdletContext.SubnetGroupIdentifier;
            }
            if (cmdletContext.VpcSecurityGroup != null)
            {
                request.VpcSecurityGroups = cmdletContext.VpcSecurityGroup;
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
        
        private Amazon.DatabaseMigrationService.Model.ModifyInstanceProfileResponse CallAWSServiceOperation(IAmazonDatabaseMigrationService client, Amazon.DatabaseMigrationService.Model.ModifyInstanceProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Database Migration Service", "ModifyInstanceProfile");
            try
            {
                #if DESKTOP
                return client.ModifyInstanceProfile(request);
                #elif CORECLR
                return client.ModifyInstanceProfileAsync(request).GetAwaiter().GetResult();
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
            public System.String AvailabilityZone { get; set; }
            public System.String Description { get; set; }
            public System.String InstanceProfileIdentifier { get; set; }
            public System.String InstanceProfileName { get; set; }
            public System.String KmsKeyArn { get; set; }
            public System.String NetworkType { get; set; }
            public System.Boolean? PubliclyAccessible { get; set; }
            public System.String SubnetGroupIdentifier { get; set; }
            public List<System.String> VpcSecurityGroup { get; set; }
            public System.Func<Amazon.DatabaseMigrationService.Model.ModifyInstanceProfileResponse, EditDMSInstanceProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InstanceProfile;
        }
        
    }
}
