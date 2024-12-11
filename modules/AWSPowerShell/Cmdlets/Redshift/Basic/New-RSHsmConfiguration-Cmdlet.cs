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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Creates an HSM configuration that contains the information required by an Amazon Redshift
    /// cluster to store and use database encryption keys in a Hardware Security Module (HSM).
    /// After creating the HSM configuration, you can specify it as a parameter when creating
    /// a cluster. The cluster will then store its encryption keys in the HSM.
    /// 
    ///  
    /// <para>
    /// In addition to creating an HSM configuration, you must also create an HSM client certificate.
    /// For more information, go to <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/working-with-HSM.html">Hardware
    /// Security Modules</a> in the Amazon Redshift Cluster Management Guide.
    /// </para>
    /// </summary>
    [Cmdlet("New", "RSHsmConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.HsmConfiguration")]
    [AWSCmdlet("Calls the Amazon Redshift CreateHsmConfiguration API operation.", Operation = new[] {"CreateHsmConfiguration"}, SelectReturnType = typeof(Amazon.Redshift.Model.CreateHsmConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Redshift.Model.HsmConfiguration or Amazon.Redshift.Model.CreateHsmConfigurationResponse",
        "This cmdlet returns an Amazon.Redshift.Model.HsmConfiguration object.",
        "The service call response (type Amazon.Redshift.Model.CreateHsmConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewRSHsmConfigurationCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A text description of the HSM configuration to be created.</para>
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
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter HsmConfigurationIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier to be assigned to the new Amazon Redshift HSM configuration.</para>
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
        public System.String HsmConfigurationIdentifier { get; set; }
        #endregion
        
        #region Parameter HsmIpAddress
        /// <summary>
        /// <para>
        /// <para>The IP address that the Amazon Redshift cluster must use to access the HSM.</para>
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
        public System.String HsmIpAddress { get; set; }
        #endregion
        
        #region Parameter HsmPartitionName
        /// <summary>
        /// <para>
        /// <para>The name of the partition in the HSM where the Amazon Redshift clusters will store
        /// their database encryption keys.</para>
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
        public System.String HsmPartitionName { get; set; }
        #endregion
        
        #region Parameter HsmPartitionPassword
        /// <summary>
        /// <para>
        /// <para>The password required to access the HSM partition.</para>
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
        public System.String HsmPartitionPassword { get; set; }
        #endregion
        
        #region Parameter HsmServerPublicCertificate
        /// <summary>
        /// <para>
        /// <para>The HSMs public certificate file. When using Cloud HSM, the file name is server.pem.</para>
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
        public System.String HsmServerPublicCertificate { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tag instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Redshift.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'HsmConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.CreateHsmConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.CreateHsmConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "HsmConfiguration";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HsmPartitionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RSHsmConfiguration (CreateHsmConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.CreateHsmConfigurationResponse, NewRSHsmConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            #if MODULAR
            if (this.Description == null && ParameterWasBound(nameof(this.Description)))
            {
                WriteWarning("You are passing $null as a value for parameter Description which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HsmConfigurationIdentifier = this.HsmConfigurationIdentifier;
            #if MODULAR
            if (this.HsmConfigurationIdentifier == null && ParameterWasBound(nameof(this.HsmConfigurationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter HsmConfigurationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HsmIpAddress = this.HsmIpAddress;
            #if MODULAR
            if (this.HsmIpAddress == null && ParameterWasBound(nameof(this.HsmIpAddress)))
            {
                WriteWarning("You are passing $null as a value for parameter HsmIpAddress which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HsmPartitionName = this.HsmPartitionName;
            #if MODULAR
            if (this.HsmPartitionName == null && ParameterWasBound(nameof(this.HsmPartitionName)))
            {
                WriteWarning("You are passing $null as a value for parameter HsmPartitionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HsmPartitionPassword = this.HsmPartitionPassword;
            #if MODULAR
            if (this.HsmPartitionPassword == null && ParameterWasBound(nameof(this.HsmPartitionPassword)))
            {
                WriteWarning("You are passing $null as a value for parameter HsmPartitionPassword which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HsmServerPublicCertificate = this.HsmServerPublicCertificate;
            #if MODULAR
            if (this.HsmServerPublicCertificate == null && ParameterWasBound(nameof(this.HsmServerPublicCertificate)))
            {
                WriteWarning("You are passing $null as a value for parameter HsmServerPublicCertificate which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Redshift.Model.Tag>(this.Tag);
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
            var request = new Amazon.Redshift.Model.CreateHsmConfigurationRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.HsmConfigurationIdentifier != null)
            {
                request.HsmConfigurationIdentifier = cmdletContext.HsmConfigurationIdentifier;
            }
            if (cmdletContext.HsmIpAddress != null)
            {
                request.HsmIpAddress = cmdletContext.HsmIpAddress;
            }
            if (cmdletContext.HsmPartitionName != null)
            {
                request.HsmPartitionName = cmdletContext.HsmPartitionName;
            }
            if (cmdletContext.HsmPartitionPassword != null)
            {
                request.HsmPartitionPassword = cmdletContext.HsmPartitionPassword;
            }
            if (cmdletContext.HsmServerPublicCertificate != null)
            {
                request.HsmServerPublicCertificate = cmdletContext.HsmServerPublicCertificate;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Redshift.Model.CreateHsmConfigurationResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.CreateHsmConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "CreateHsmConfiguration");
            try
            {
                #if DESKTOP
                return client.CreateHsmConfiguration(request);
                #elif CORECLR
                return client.CreateHsmConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String HsmConfigurationIdentifier { get; set; }
            public System.String HsmIpAddress { get; set; }
            public System.String HsmPartitionName { get; set; }
            public System.String HsmPartitionPassword { get; set; }
            public System.String HsmServerPublicCertificate { get; set; }
            public List<Amazon.Redshift.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Redshift.Model.CreateHsmConfigurationResponse, NewRSHsmConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.HsmConfiguration;
        }
        
    }
}
