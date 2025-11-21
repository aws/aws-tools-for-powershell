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
using System.Threading;
using Amazon.Redshift;
using Amazon.Redshift.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Modifies the lakehouse configuration for a cluster. This operation allows you to manage
    /// Amazon Redshift federated permissions and Amazon Web Services IAM Identity Center
    /// trusted identity propagation.
    /// </summary>
    [Cmdlet("Edit", "RSLakehouseConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.ModifyLakehouseConfigurationResponse")]
    [AWSCmdlet("Calls the Amazon Redshift ModifyLakehouseConfiguration API operation.", Operation = new[] {"ModifyLakehouseConfiguration"}, SelectReturnType = typeof(Amazon.Redshift.Model.ModifyLakehouseConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Redshift.Model.ModifyLakehouseConfigurationResponse",
        "This cmdlet returns an Amazon.Redshift.Model.ModifyLakehouseConfigurationResponse object containing multiple properties."
    )]
    public partial class EditRSLakehouseConfigurationCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CatalogName
        /// <summary>
        /// <para>
        /// <para>The name of the Glue data catalog that will be associated with the cluster enabled
        /// with Amazon Redshift federated permissions.</para><para>Constraints:</para><ul><li><para>Must contain at least one lowercase letter.</para></li><li><para>Can only contain lowercase letters (a-z), numbers (0-9), underscores (_), and hyphens
        /// (-).</para></li></ul><para>Pattern: <c>^[a-z0-9_-]*[a-z]+[a-z0-9_-]*$</c></para><para>Example: <c>my-catalog_01</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CatalogName { get; set; }
        #endregion
        
        #region Parameter ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the cluster whose lakehouse configuration you want to modify.</para>
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
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>A boolean value that, if <c>true</c>, validates the request without actually modifying
        /// the lakehouse configuration. Use this to check for errors before making changes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter LakehouseIdcApplicationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM Identity Center application used for enabling
        /// Amazon Web Services IAM Identity Center trusted identity propagation on a cluster
        /// enabled with Amazon Redshift federated permissions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LakehouseIdcApplicationArn { get; set; }
        #endregion
        
        #region Parameter LakehouseIdcRegistration
        /// <summary>
        /// <para>
        /// <para>Modifies the Amazon Web Services IAM Identity Center trusted identity propagation
        /// on a cluster enabled with Amazon Redshift federated permissions. Valid values are
        /// <c>Associate</c> or <c>Disassociate</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Redshift.LakehouseIdcRegistration")]
        public Amazon.Redshift.LakehouseIdcRegistration LakehouseIdcRegistration { get; set; }
        #endregion
        
        #region Parameter LakehouseRegistration
        /// <summary>
        /// <para>
        /// <para>Specifies whether to register or deregister the cluster with Amazon Redshift federated
        /// permissions. Valid values are <c>Register</c> or <c>Deregister</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Redshift.LakehouseRegistration")]
        public Amazon.Redshift.LakehouseRegistration LakehouseRegistration { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.ModifyLakehouseConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.ModifyLakehouseConfigurationResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RSLakehouseConfiguration (ModifyLakehouseConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.ModifyLakehouseConfigurationResponse, EditRSLakehouseConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CatalogName = this.CatalogName;
            context.ClusterIdentifier = this.ClusterIdentifier;
            #if MODULAR
            if (this.ClusterIdentifier == null && ParameterWasBound(nameof(this.ClusterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DryRun = this.DryRun;
            context.LakehouseIdcApplicationArn = this.LakehouseIdcApplicationArn;
            context.LakehouseIdcRegistration = this.LakehouseIdcRegistration;
            context.LakehouseRegistration = this.LakehouseRegistration;
            
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
            var request = new Amazon.Redshift.Model.ModifyLakehouseConfigurationRequest();
            
            if (cmdletContext.CatalogName != null)
            {
                request.CatalogName = cmdletContext.CatalogName;
            }
            if (cmdletContext.ClusterIdentifier != null)
            {
                request.ClusterIdentifier = cmdletContext.ClusterIdentifier;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.LakehouseIdcApplicationArn != null)
            {
                request.LakehouseIdcApplicationArn = cmdletContext.LakehouseIdcApplicationArn;
            }
            if (cmdletContext.LakehouseIdcRegistration != null)
            {
                request.LakehouseIdcRegistration = cmdletContext.LakehouseIdcRegistration;
            }
            if (cmdletContext.LakehouseRegistration != null)
            {
                request.LakehouseRegistration = cmdletContext.LakehouseRegistration;
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
        
        private Amazon.Redshift.Model.ModifyLakehouseConfigurationResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.ModifyLakehouseConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "ModifyLakehouseConfiguration");
            try
            {
                return client.ModifyLakehouseConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CatalogName { get; set; }
            public System.String ClusterIdentifier { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.String LakehouseIdcApplicationArn { get; set; }
            public Amazon.Redshift.LakehouseIdcRegistration LakehouseIdcRegistration { get; set; }
            public Amazon.Redshift.LakehouseRegistration LakehouseRegistration { get; set; }
            public System.Func<Amazon.Redshift.Model.ModifyLakehouseConfigurationResponse, EditRSLakehouseConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
