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
using Amazon.RedshiftServerless;
using Amazon.RedshiftServerless.Model;

namespace Amazon.PowerShell.Cmdlets.RSS
{
    /// <summary>
    /// Modifies the lakehouse configuration for a namespace. This operation allows you to
    /// manage Amazon Redshift federated permissions and Amazon Web Services IAM Identity
    /// Center trusted identity propagation.
    /// </summary>
    [Cmdlet("Update", "RSSLakehouseConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RedshiftServerless.Model.UpdateLakehouseConfigurationResponse")]
    [AWSCmdlet("Calls the Redshift Serverless UpdateLakehouseConfiguration API operation.", Operation = new[] {"UpdateLakehouseConfiguration"}, SelectReturnType = typeof(Amazon.RedshiftServerless.Model.UpdateLakehouseConfigurationResponse))]
    [AWSCmdletOutput("Amazon.RedshiftServerless.Model.UpdateLakehouseConfigurationResponse",
        "This cmdlet returns an Amazon.RedshiftServerless.Model.UpdateLakehouseConfigurationResponse object containing multiple properties."
    )]
    public partial class UpdateRSSLakehouseConfigurationCmdlet : AmazonRedshiftServerlessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CatalogName
        /// <summary>
        /// <para>
        /// <para>The name of the Glue Data Catalog that will be associated with the namespace enabled
        /// with Amazon Redshift federated permissions.</para><para>Pattern: <c>^[a-z0-9_-]*[a-z]+[a-z0-9_-]*$</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CatalogName { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>A boolean value that, if <c>true</c>, validates the request without actually updating
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
        /// Amazon Web Services IAM Identity Center trusted identity propagation on a namespace
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
        /// on a namespace enabled with Amazon Redshift federated permissions. Valid values are
        /// <c>Associate</c> or <c>Disassociate</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.RedshiftServerless.LakehouseIdcRegistration")]
        public Amazon.RedshiftServerless.LakehouseIdcRegistration LakehouseIdcRegistration { get; set; }
        #endregion
        
        #region Parameter LakehouseRegistration
        /// <summary>
        /// <para>
        /// <para>Specifies whether to register or deregister the namespace with Amazon Redshift federated
        /// permissions. Valid values are <c>Register</c> or <c>Deregister</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.RedshiftServerless.LakehouseRegistration")]
        public Amazon.RedshiftServerless.LakehouseRegistration LakehouseRegistration { get; set; }
        #endregion
        
        #region Parameter NamespaceName
        /// <summary>
        /// <para>
        /// <para>The name of the namespace whose lakehouse configuration you want to modify.</para>
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
        public System.String NamespaceName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RedshiftServerless.Model.UpdateLakehouseConfigurationResponse).
        /// Specifying the name of a property of type Amazon.RedshiftServerless.Model.UpdateLakehouseConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the NamespaceName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^NamespaceName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^NamespaceName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NamespaceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-RSSLakehouseConfiguration (UpdateLakehouseConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RedshiftServerless.Model.UpdateLakehouseConfigurationResponse, UpdateRSSLakehouseConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.NamespaceName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CatalogName = this.CatalogName;
            context.DryRun = this.DryRun;
            context.LakehouseIdcApplicationArn = this.LakehouseIdcApplicationArn;
            context.LakehouseIdcRegistration = this.LakehouseIdcRegistration;
            context.LakehouseRegistration = this.LakehouseRegistration;
            context.NamespaceName = this.NamespaceName;
            #if MODULAR
            if (this.NamespaceName == null && ParameterWasBound(nameof(this.NamespaceName)))
            {
                WriteWarning("You are passing $null as a value for parameter NamespaceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RedshiftServerless.Model.UpdateLakehouseConfigurationRequest();
            
            if (cmdletContext.CatalogName != null)
            {
                request.CatalogName = cmdletContext.CatalogName;
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
            if (cmdletContext.NamespaceName != null)
            {
                request.NamespaceName = cmdletContext.NamespaceName;
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
        
        private Amazon.RedshiftServerless.Model.UpdateLakehouseConfigurationResponse CallAWSServiceOperation(IAmazonRedshiftServerless client, Amazon.RedshiftServerless.Model.UpdateLakehouseConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Redshift Serverless", "UpdateLakehouseConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateLakehouseConfiguration(request);
                #elif CORECLR
                return client.UpdateLakehouseConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String CatalogName { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.String LakehouseIdcApplicationArn { get; set; }
            public Amazon.RedshiftServerless.LakehouseIdcRegistration LakehouseIdcRegistration { get; set; }
            public Amazon.RedshiftServerless.LakehouseRegistration LakehouseRegistration { get; set; }
            public System.String NamespaceName { get; set; }
            public System.Func<Amazon.RedshiftServerless.Model.UpdateLakehouseConfigurationResponse, UpdateRSSLakehouseConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
