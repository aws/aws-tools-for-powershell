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
using Amazon.PCS;
using Amazon.PCS.Model;

namespace Amazon.PowerShell.Cmdlets.PCS
{
    /// <summary>
    /// Updates a cluster configuration. You can modify Slurm scheduler settings, accounting
    /// configuration, and security groups for an existing cluster. 
    /// 
    ///  <note><para>
    /// You can only update clusters that are in <c>ACTIVE</c>, <c>UPDATE_FAILED</c>, or <c>SUSPENDED</c>
    /// state. All associated resources (queues and compute node groups) must be in <c>ACTIVE</c>
    /// state before you can update the cluster.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "PCSCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PCS.Model.Cluster")]
    [AWSCmdlet("Calls the AWS Parallel Computing Service UpdateCluster API operation.", Operation = new[] {"UpdateCluster"}, SelectReturnType = typeof(Amazon.PCS.Model.UpdateClusterResponse))]
    [AWSCmdletOutput("Amazon.PCS.Model.Cluster or Amazon.PCS.Model.UpdateClusterResponse",
        "This cmdlet returns an Amazon.PCS.Model.Cluster object.",
        "The service call response (type Amazon.PCS.Model.UpdateClusterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdatePCSClusterCmdlet : AmazonPCSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The name or ID of the cluster to update.</para>
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
        public System.String ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter Accounting_DefaultPurgeTimeInDay
        /// <summary>
        /// <para>
        /// <para>The default value for all purge settings for <c>slurmdbd.conf</c>. For more information,
        /// see the <a href="https://slurm.schedmd.com/slurmdbd.conf.html">slurmdbd.conf documentation
        /// at SchedMD</a>.</para><para>The default value for <c>defaultPurgeTimeInDays</c> is <c>-1</c>.</para><para>A value of <c>-1</c> means there is no purge time and records persist as long as the
        /// cluster exists.</para><important><para><c>0</c> isn't a valid value.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SlurmConfiguration_Accounting_DefaultPurgeTimeInDays")]
        public System.Int32? Accounting_DefaultPurgeTimeInDay { get; set; }
        #endregion
        
        #region Parameter Accounting_Mode
        /// <summary>
        /// <para>
        /// <para>The default value for <c>mode</c> is <c>NONE</c>. A value of <c>STANDARD</c> means
        /// Slurm accounting is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SlurmConfiguration_Accounting_Mode")]
        [AWSConstantClassSource("Amazon.PCS.AccountingMode")]
        public Amazon.PCS.AccountingMode Accounting_Mode { get; set; }
        #endregion
        
        #region Parameter SlurmRest_Mode
        /// <summary>
        /// <para>
        /// <para>The default value for <c>mode</c> is <c>NONE</c>. A value of <c>STANDARD</c> means
        /// the Slurm REST API is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SlurmConfiguration_SlurmRest_Mode")]
        [AWSConstantClassSource("Amazon.PCS.SlurmRestMode")]
        public Amazon.PCS.SlurmRestMode SlurmRest_Mode { get; set; }
        #endregion
        
        #region Parameter SlurmConfiguration_ScaleDownIdleTimeInSecond
        /// <summary>
        /// <para>
        /// <para>The time (in seconds) before an idle node is scaled down.</para><para>Default: <c>600</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SlurmConfiguration_ScaleDownIdleTimeInSeconds")]
        public System.Int32? SlurmConfiguration_ScaleDownIdleTimeInSecond { get; set; }
        #endregion
        
        #region Parameter SlurmConfiguration_SlurmCustomSetting
        /// <summary>
        /// <para>
        /// <para>Additional Slurm-specific configuration that directly maps to Slurm settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SlurmConfiguration_SlurmCustomSettings")]
        public Amazon.PCS.Model.SlurmCustomSetting[] SlurmConfiguration_SlurmCustomSetting { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. Idempotency ensures that an API request completes only once. With an
        /// idempotent request, if the original request completes successfully, the subsequent
        /// retries with the same client token return the result from the original successful
        /// request and they have no additional effect. If you don't specify a client token, the
        /// CLI and SDK automatically generate 1 for you.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Cluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PCS.Model.UpdateClusterResponse).
        /// Specifying the name of a property of type Amazon.PCS.Model.UpdateClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Cluster";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ClusterIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ClusterIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ClusterIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PCSCluster (UpdateCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PCS.Model.UpdateClusterResponse, UpdatePCSClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ClusterIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.ClusterIdentifier = this.ClusterIdentifier;
            #if MODULAR
            if (this.ClusterIdentifier == null && ParameterWasBound(nameof(this.ClusterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Accounting_DefaultPurgeTimeInDay = this.Accounting_DefaultPurgeTimeInDay;
            context.Accounting_Mode = this.Accounting_Mode;
            context.SlurmConfiguration_ScaleDownIdleTimeInSecond = this.SlurmConfiguration_ScaleDownIdleTimeInSecond;
            if (this.SlurmConfiguration_SlurmCustomSetting != null)
            {
                context.SlurmConfiguration_SlurmCustomSetting = new List<Amazon.PCS.Model.SlurmCustomSetting>(this.SlurmConfiguration_SlurmCustomSetting);
            }
            context.SlurmRest_Mode = this.SlurmRest_Mode;
            
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
            var request = new Amazon.PCS.Model.UpdateClusterRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ClusterIdentifier != null)
            {
                request.ClusterIdentifier = cmdletContext.ClusterIdentifier;
            }
            
             // populate SlurmConfiguration
            var requestSlurmConfigurationIsNull = true;
            request.SlurmConfiguration = new Amazon.PCS.Model.UpdateClusterSlurmConfigurationRequest();
            System.Int32? requestSlurmConfiguration_slurmConfiguration_ScaleDownIdleTimeInSecond = null;
            if (cmdletContext.SlurmConfiguration_ScaleDownIdleTimeInSecond != null)
            {
                requestSlurmConfiguration_slurmConfiguration_ScaleDownIdleTimeInSecond = cmdletContext.SlurmConfiguration_ScaleDownIdleTimeInSecond.Value;
            }
            if (requestSlurmConfiguration_slurmConfiguration_ScaleDownIdleTimeInSecond != null)
            {
                request.SlurmConfiguration.ScaleDownIdleTimeInSeconds = requestSlurmConfiguration_slurmConfiguration_ScaleDownIdleTimeInSecond.Value;
                requestSlurmConfigurationIsNull = false;
            }
            List<Amazon.PCS.Model.SlurmCustomSetting> requestSlurmConfiguration_slurmConfiguration_SlurmCustomSetting = null;
            if (cmdletContext.SlurmConfiguration_SlurmCustomSetting != null)
            {
                requestSlurmConfiguration_slurmConfiguration_SlurmCustomSetting = cmdletContext.SlurmConfiguration_SlurmCustomSetting;
            }
            if (requestSlurmConfiguration_slurmConfiguration_SlurmCustomSetting != null)
            {
                request.SlurmConfiguration.SlurmCustomSettings = requestSlurmConfiguration_slurmConfiguration_SlurmCustomSetting;
                requestSlurmConfigurationIsNull = false;
            }
            Amazon.PCS.Model.UpdateSlurmRestRequest requestSlurmConfiguration_slurmConfiguration_SlurmRest = null;
            
             // populate SlurmRest
            var requestSlurmConfiguration_slurmConfiguration_SlurmRestIsNull = true;
            requestSlurmConfiguration_slurmConfiguration_SlurmRest = new Amazon.PCS.Model.UpdateSlurmRestRequest();
            Amazon.PCS.SlurmRestMode requestSlurmConfiguration_slurmConfiguration_SlurmRest_slurmRest_Mode = null;
            if (cmdletContext.SlurmRest_Mode != null)
            {
                requestSlurmConfiguration_slurmConfiguration_SlurmRest_slurmRest_Mode = cmdletContext.SlurmRest_Mode;
            }
            if (requestSlurmConfiguration_slurmConfiguration_SlurmRest_slurmRest_Mode != null)
            {
                requestSlurmConfiguration_slurmConfiguration_SlurmRest.Mode = requestSlurmConfiguration_slurmConfiguration_SlurmRest_slurmRest_Mode;
                requestSlurmConfiguration_slurmConfiguration_SlurmRestIsNull = false;
            }
             // determine if requestSlurmConfiguration_slurmConfiguration_SlurmRest should be set to null
            if (requestSlurmConfiguration_slurmConfiguration_SlurmRestIsNull)
            {
                requestSlurmConfiguration_slurmConfiguration_SlurmRest = null;
            }
            if (requestSlurmConfiguration_slurmConfiguration_SlurmRest != null)
            {
                request.SlurmConfiguration.SlurmRest = requestSlurmConfiguration_slurmConfiguration_SlurmRest;
                requestSlurmConfigurationIsNull = false;
            }
            Amazon.PCS.Model.UpdateAccountingRequest requestSlurmConfiguration_slurmConfiguration_Accounting = null;
            
             // populate Accounting
            var requestSlurmConfiguration_slurmConfiguration_AccountingIsNull = true;
            requestSlurmConfiguration_slurmConfiguration_Accounting = new Amazon.PCS.Model.UpdateAccountingRequest();
            System.Int32? requestSlurmConfiguration_slurmConfiguration_Accounting_accounting_DefaultPurgeTimeInDay = null;
            if (cmdletContext.Accounting_DefaultPurgeTimeInDay != null)
            {
                requestSlurmConfiguration_slurmConfiguration_Accounting_accounting_DefaultPurgeTimeInDay = cmdletContext.Accounting_DefaultPurgeTimeInDay.Value;
            }
            if (requestSlurmConfiguration_slurmConfiguration_Accounting_accounting_DefaultPurgeTimeInDay != null)
            {
                requestSlurmConfiguration_slurmConfiguration_Accounting.DefaultPurgeTimeInDays = requestSlurmConfiguration_slurmConfiguration_Accounting_accounting_DefaultPurgeTimeInDay.Value;
                requestSlurmConfiguration_slurmConfiguration_AccountingIsNull = false;
            }
            Amazon.PCS.AccountingMode requestSlurmConfiguration_slurmConfiguration_Accounting_accounting_Mode = null;
            if (cmdletContext.Accounting_Mode != null)
            {
                requestSlurmConfiguration_slurmConfiguration_Accounting_accounting_Mode = cmdletContext.Accounting_Mode;
            }
            if (requestSlurmConfiguration_slurmConfiguration_Accounting_accounting_Mode != null)
            {
                requestSlurmConfiguration_slurmConfiguration_Accounting.Mode = requestSlurmConfiguration_slurmConfiguration_Accounting_accounting_Mode;
                requestSlurmConfiguration_slurmConfiguration_AccountingIsNull = false;
            }
             // determine if requestSlurmConfiguration_slurmConfiguration_Accounting should be set to null
            if (requestSlurmConfiguration_slurmConfiguration_AccountingIsNull)
            {
                requestSlurmConfiguration_slurmConfiguration_Accounting = null;
            }
            if (requestSlurmConfiguration_slurmConfiguration_Accounting != null)
            {
                request.SlurmConfiguration.Accounting = requestSlurmConfiguration_slurmConfiguration_Accounting;
                requestSlurmConfigurationIsNull = false;
            }
             // determine if request.SlurmConfiguration should be set to null
            if (requestSlurmConfigurationIsNull)
            {
                request.SlurmConfiguration = null;
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
        
        private Amazon.PCS.Model.UpdateClusterResponse CallAWSServiceOperation(IAmazonPCS client, Amazon.PCS.Model.UpdateClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Parallel Computing Service", "UpdateCluster");
            try
            {
                #if DESKTOP
                return client.UpdateCluster(request);
                #elif CORECLR
                return client.UpdateClusterAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String ClusterIdentifier { get; set; }
            public System.Int32? Accounting_DefaultPurgeTimeInDay { get; set; }
            public Amazon.PCS.AccountingMode Accounting_Mode { get; set; }
            public System.Int32? SlurmConfiguration_ScaleDownIdleTimeInSecond { get; set; }
            public List<Amazon.PCS.Model.SlurmCustomSetting> SlurmConfiguration_SlurmCustomSetting { get; set; }
            public Amazon.PCS.SlurmRestMode SlurmRest_Mode { get; set; }
            public System.Func<Amazon.PCS.Model.UpdateClusterResponse, UpdatePCSClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Cluster;
        }
        
    }
}
