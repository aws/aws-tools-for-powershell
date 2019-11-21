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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Updates a notebook instance. NotebookInstance updates include upgrading or downgrading
    /// the ML compute instance used for your notebook instance to accommodate changes in
    /// your workload requirements.
    /// </summary>
    [Cmdlet("Update", "SMNotebookInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon SageMaker Service UpdateNotebookInstance API operation.", Operation = new[] {"UpdateNotebookInstance"}, SelectReturnType = typeof(Amazon.SageMaker.Model.UpdateNotebookInstanceResponse))]
    [AWSCmdletOutput("None or Amazon.SageMaker.Model.UpdateNotebookInstanceResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SageMaker.Model.UpdateNotebookInstanceResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSMNotebookInstanceCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter AcceleratorType
        /// <summary>
        /// <para>
        /// <para>A list of the Elastic Inference (EI) instance types to associate with this notebook
        /// instance. Currently only one EI instance type can be associated with a notebook instance.
        /// For more information, see <a href="sagemaker/latest/dg/ei.html">Using Elastic Inference
        /// in Amazon SageMaker</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AcceleratorTypes")]
        public System.String[] AcceleratorType { get; set; }
        #endregion
        
        #region Parameter AdditionalCodeRepository
        /// <summary>
        /// <para>
        /// <para>An array of up to three Git repositories to associate with the notebook instance.
        /// These can be either the names of Git repositories stored as resources in your account,
        /// or the URL of Git repositories in <a href="https://docs.aws.amazon.com/codecommit/latest/userguide/welcome.html">AWS
        /// CodeCommit</a> or in any other Git repository. These repositories are cloned at the
        /// same level as the default repository of your notebook instance. For more information,
        /// see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/nbi-git-repo.html">Associating
        /// Git Repositories with Amazon SageMaker Notebook Instances</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdditionalCodeRepositories")]
        public System.String[] AdditionalCodeRepository { get; set; }
        #endregion
        
        #region Parameter DefaultCodeRepository
        /// <summary>
        /// <para>
        /// <para>The Git repository to associate with the notebook instance as its default code repository.
        /// This can be either the name of a Git repository stored as a resource in your account,
        /// or the URL of a Git repository in <a href="https://docs.aws.amazon.com/codecommit/latest/userguide/welcome.html">AWS
        /// CodeCommit</a> or in any other Git repository. When you open a notebook instance,
        /// it opens in the directory that contains this repository. For more information, see
        /// <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/nbi-git-repo.html">Associating
        /// Git Repositories with Amazon SageMaker Notebook Instances</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultCodeRepository { get; set; }
        #endregion
        
        #region Parameter DisassociateAcceleratorType
        /// <summary>
        /// <para>
        /// <para>A list of the Elastic Inference (EI) instance types to remove from this notebook instance.
        /// This operation is idempotent. If you specify an accelerator type that is not associated
        /// with the notebook instance when you call this method, it does not throw an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DisassociateAcceleratorTypes")]
        public System.Boolean? DisassociateAcceleratorType { get; set; }
        #endregion
        
        #region Parameter DisassociateAdditionalCodeRepository
        /// <summary>
        /// <para>
        /// <para>A list of names or URLs of the default Git repositories to remove from this notebook
        /// instance. This operation is idempotent. If you specify a Git repository that is not
        /// associated with the notebook instance when you call this method, it does not throw
        /// an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DisassociateAdditionalCodeRepositories")]
        public System.Boolean? DisassociateAdditionalCodeRepository { get; set; }
        #endregion
        
        #region Parameter DisassociateDefaultCodeRepository
        /// <summary>
        /// <para>
        /// <para>The name or URL of the default Git repository to remove from this notebook instance.
        /// This operation is idempotent. If you specify a Git repository that is not associated
        /// with the notebook instance when you call this method, it does not throw an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DisassociateDefaultCodeRepository { get; set; }
        #endregion
        
        #region Parameter DisassociateLifecycleConfig
        /// <summary>
        /// <para>
        /// <para>Set to <code>true</code> to remove the notebook instance lifecycle configuration currently
        /// associated with the notebook instance. This operation is idempotent. If you specify
        /// a lifecycle configuration that is not associated with the notebook instance when you
        /// call this method, it does not throw an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DisassociateLifecycleConfig { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>The Amazon ML compute instance type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.InstanceType")]
        public Amazon.SageMaker.InstanceType InstanceType { get; set; }
        #endregion
        
        #region Parameter LifecycleConfigName
        /// <summary>
        /// <para>
        /// <para>The name of a lifecycle configuration to associate with the notebook instance. For
        /// information about lifestyle configurations, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/notebook-lifecycle-config.html">Step
        /// 2.1: (Optional) Customize a Notebook Instance</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LifecycleConfigName { get; set; }
        #endregion
        
        #region Parameter NotebookInstanceName
        /// <summary>
        /// <para>
        /// <para>The name of the notebook instance to update.</para>
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
        public System.String NotebookInstanceName { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that Amazon SageMaker can assume to
        /// access the notebook instance. For more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/sagemaker-roles.html">Amazon
        /// SageMaker Roles</a>. </para><note><para>To be able to pass this role to Amazon SageMaker, the caller of this API must have
        /// the <code>iam:PassRole</code> permission.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter RootAccess
        /// <summary>
        /// <para>
        /// <para>Whether root access is enabled or disabled for users of the notebook instance. The
        /// default value is <code>Enabled</code>.</para><note><para>If you set this to <code>Disabled</code>, users don't have root access on the notebook
        /// instance, but lifecycle configuration scripts still run with root permissions.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.RootAccess")]
        public Amazon.SageMaker.RootAccess RootAccess { get; set; }
        #endregion
        
        #region Parameter VolumeSizeInGB
        /// <summary>
        /// <para>
        /// <para>The size, in GB, of the ML storage volume to attach to the notebook instance. The
        /// default value is 5 GB. ML storage volumes are encrypted, so Amazon SageMaker can't
        /// determine the amount of available free space on the volume. Because of this, you can
        /// increase the volume size when you update a notebook instance, but you can't decrease
        /// the volume size. If you want to decrease the size of the ML storage volume in use,
        /// create a new notebook instance with the desired size.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? VolumeSizeInGB { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.UpdateNotebookInstanceResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the NotebookInstanceName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^NotebookInstanceName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^NotebookInstanceName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NotebookInstanceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMNotebookInstance (UpdateNotebookInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdateNotebookInstanceResponse, UpdateSMNotebookInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.NotebookInstanceName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AcceleratorType != null)
            {
                context.AcceleratorType = new List<System.String>(this.AcceleratorType);
            }
            if (this.AdditionalCodeRepository != null)
            {
                context.AdditionalCodeRepository = new List<System.String>(this.AdditionalCodeRepository);
            }
            context.DefaultCodeRepository = this.DefaultCodeRepository;
            context.DisassociateAcceleratorType = this.DisassociateAcceleratorType;
            context.DisassociateAdditionalCodeRepository = this.DisassociateAdditionalCodeRepository;
            context.DisassociateDefaultCodeRepository = this.DisassociateDefaultCodeRepository;
            context.DisassociateLifecycleConfig = this.DisassociateLifecycleConfig;
            context.InstanceType = this.InstanceType;
            context.LifecycleConfigName = this.LifecycleConfigName;
            context.NotebookInstanceName = this.NotebookInstanceName;
            #if MODULAR
            if (this.NotebookInstanceName == null && ParameterWasBound(nameof(this.NotebookInstanceName)))
            {
                WriteWarning("You are passing $null as a value for parameter NotebookInstanceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            context.RootAccess = this.RootAccess;
            context.VolumeSizeInGB = this.VolumeSizeInGB;
            
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
            var request = new Amazon.SageMaker.Model.UpdateNotebookInstanceRequest();
            
            if (cmdletContext.AcceleratorType != null)
            {
                request.AcceleratorTypes = cmdletContext.AcceleratorType;
            }
            if (cmdletContext.AdditionalCodeRepository != null)
            {
                request.AdditionalCodeRepositories = cmdletContext.AdditionalCodeRepository;
            }
            if (cmdletContext.DefaultCodeRepository != null)
            {
                request.DefaultCodeRepository = cmdletContext.DefaultCodeRepository;
            }
            if (cmdletContext.DisassociateAcceleratorType != null)
            {
                request.DisassociateAcceleratorTypes = cmdletContext.DisassociateAcceleratorType.Value;
            }
            if (cmdletContext.DisassociateAdditionalCodeRepository != null)
            {
                request.DisassociateAdditionalCodeRepositories = cmdletContext.DisassociateAdditionalCodeRepository.Value;
            }
            if (cmdletContext.DisassociateDefaultCodeRepository != null)
            {
                request.DisassociateDefaultCodeRepository = cmdletContext.DisassociateDefaultCodeRepository.Value;
            }
            if (cmdletContext.DisassociateLifecycleConfig != null)
            {
                request.DisassociateLifecycleConfig = cmdletContext.DisassociateLifecycleConfig.Value;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceType = cmdletContext.InstanceType;
            }
            if (cmdletContext.LifecycleConfigName != null)
            {
                request.LifecycleConfigName = cmdletContext.LifecycleConfigName;
            }
            if (cmdletContext.NotebookInstanceName != null)
            {
                request.NotebookInstanceName = cmdletContext.NotebookInstanceName;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.RootAccess != null)
            {
                request.RootAccess = cmdletContext.RootAccess;
            }
            if (cmdletContext.VolumeSizeInGB != null)
            {
                request.VolumeSizeInGB = cmdletContext.VolumeSizeInGB.Value;
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
        
        private Amazon.SageMaker.Model.UpdateNotebookInstanceResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.UpdateNotebookInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "UpdateNotebookInstance");
            try
            {
                #if DESKTOP
                return client.UpdateNotebookInstance(request);
                #elif CORECLR
                return client.UpdateNotebookInstanceAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AcceleratorType { get; set; }
            public List<System.String> AdditionalCodeRepository { get; set; }
            public System.String DefaultCodeRepository { get; set; }
            public System.Boolean? DisassociateAcceleratorType { get; set; }
            public System.Boolean? DisassociateAdditionalCodeRepository { get; set; }
            public System.Boolean? DisassociateDefaultCodeRepository { get; set; }
            public System.Boolean? DisassociateLifecycleConfig { get; set; }
            public Amazon.SageMaker.InstanceType InstanceType { get; set; }
            public System.String LifecycleConfigName { get; set; }
            public System.String NotebookInstanceName { get; set; }
            public System.String RoleArn { get; set; }
            public Amazon.SageMaker.RootAccess RootAccess { get; set; }
            public System.Int32? VolumeSizeInGB { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdateNotebookInstanceResponse, UpdateSMNotebookInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
