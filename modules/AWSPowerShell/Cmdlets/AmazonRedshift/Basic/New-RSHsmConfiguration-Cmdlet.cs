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
    /// For more information, go to <a href="http://docs.aws.amazon.com/redshift/latest/mgmt/working-with-HSM.html">Hardware
    /// Security Modules</a> in the Amazon Redshift Cluster Management Guide.
    /// </para>
    /// </summary>
    [Cmdlet("New", "RSHsmConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.HsmConfiguration")]
    [AWSCmdlet("Invokes the CreateHsmConfiguration operation against Amazon Redshift.", Operation = new[] {"CreateHsmConfiguration"})]
    [AWSCmdletOutput("Amazon.Redshift.Model.HsmConfiguration",
        "This cmdlet returns a HsmConfiguration object.",
        "The service call response (type CreateHsmConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewRSHsmConfigurationCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>A text description of the HSM configuration to be created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Description { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The identifier to be assigned to the new Amazon Redshift HSM configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String HsmConfigurationIdentifier { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The IP address that the Amazon Redshift cluster must use to access the HSM.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String HsmIpAddress { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the partition in the HSM where the Amazon Redshift clusters will store
        /// their database encryption keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String HsmPartitionName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The password required to access the HSM partition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String HsmPartitionPassword { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The HSMs public certificate file. When using Cloud HSM, the file name is server.pem.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String HsmServerPublicCertificate { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of tag instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.Redshift.Model.Tag[] Tag { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("HsmPartitionName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RSHsmConfiguration (CreateHsmConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Description = this.Description;
            context.HsmConfigurationIdentifier = this.HsmConfigurationIdentifier;
            context.HsmIpAddress = this.HsmIpAddress;
            context.HsmPartitionName = this.HsmPartitionName;
            context.HsmPartitionPassword = this.HsmPartitionPassword;
            context.HsmServerPublicCertificate = this.HsmServerPublicCertificate;
            if (this.Tag != null)
            {
                context.Tags = new List<Tag>(this.Tag);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CreateHsmConfigurationRequest();
            
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
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateHsmConfiguration(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.HsmConfiguration;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String Description { get; set; }
            public String HsmConfigurationIdentifier { get; set; }
            public String HsmIpAddress { get; set; }
            public String HsmPartitionName { get; set; }
            public String HsmPartitionPassword { get; set; }
            public String HsmServerPublicCertificate { get; set; }
            public List<Tag> Tags { get; set; }
        }
        
    }
}
