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
    /// Creates an SageMaker notebook instance. A notebook instance is a machine learning
    /// (ML) compute instance running on a Jupyter notebook. 
    /// 
    ///  
    /// <para>
    /// In a <c>CreateNotebookInstance</c> request, specify the type of ML compute instance
    /// that you want to run. SageMaker launches the instance, installs common libraries that
    /// you can use to explore datasets for model training, and attaches an ML storage volume
    /// to the notebook instance. 
    /// </para><para>
    /// SageMaker also provides a set of example notebooks. Each notebook demonstrates how
    /// to use SageMaker with a specific algorithm or with a machine learning framework. 
    /// </para><para>
    /// After receiving the request, SageMaker does the following:
    /// </para><ol><li><para>
    /// Creates a network interface in the SageMaker VPC.
    /// </para></li><li><para>
    /// (Option) If you specified <c>SubnetId</c>, SageMaker creates a network interface in
    /// your own VPC, which is inferred from the subnet ID that you provide in the input.
    /// When creating this network interface, SageMaker attaches the security group that you
    /// specified in the request to the network interface that it creates in your VPC.
    /// </para></li><li><para>
    /// Launches an EC2 instance of the type specified in the request in the SageMaker VPC.
    /// If you specified <c>SubnetId</c> of your VPC, SageMaker specifies both network interfaces
    /// when launching this instance. This enables inbound traffic from your own VPC to the
    /// notebook instance, assuming that the security groups allow it.
    /// </para></li></ol><para>
    /// After creating the notebook instance, SageMaker returns its Amazon Resource Name (ARN).
    /// You can't change the name of a notebook instance after you create it.
    /// </para><para>
    /// After SageMaker creates the notebook instance, you can connect to the Jupyter server
    /// and work in Jupyter notebooks. For example, you can write code to explore a dataset
    /// that you can use for model training, train a model, host models by creating SageMaker
    /// endpoints, and validate hosted models. 
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/how-it-works.html">How
    /// It Works</a>. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "SMNotebookInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateNotebookInstance API operation.", Operation = new[] {"CreateNotebookInstance"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateNotebookInstanceResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateNotebookInstanceResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateNotebookInstanceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMNotebookInstanceCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AcceleratorType
        /// <summary>
        /// <para>
        /// <para>A list of Elastic Inference (EI) instance types to associate with this notebook instance.
        /// Currently, only one instance type can be associated with a notebook instance. For
        /// more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/ei.html">Using
        /// Elastic Inference in Amazon SageMaker</a>.</para>
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
        /// or the URL of Git repositories in <a href="https://docs.aws.amazon.com/codecommit/latest/userguide/welcome.html">Amazon
        /// Web Services CodeCommit</a> or in any other Git repository. These repositories are
        /// cloned at the same level as the default repository of your notebook instance. For
        /// more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/nbi-git-repo.html">Associating
        /// Git Repositories with SageMaker Notebook Instances</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdditionalCodeRepositories")]
        public System.String[] AdditionalCodeRepository { get; set; }
        #endregion
        
        #region Parameter DefaultCodeRepository
        /// <summary>
        /// <para>
        /// <para>A Git repository to associate with the notebook instance as its default code repository.
        /// This can be either the name of a Git repository stored as a resource in your account,
        /// or the URL of a Git repository in <a href="https://docs.aws.amazon.com/codecommit/latest/userguide/welcome.html">Amazon
        /// Web Services CodeCommit</a> or in any other Git repository. When you open a notebook
        /// instance, it opens in the directory that contains this repository. For more information,
        /// see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/nbi-git-repo.html">Associating
        /// Git Repositories with SageMaker Notebook Instances</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultCodeRepository { get; set; }
        #endregion
        
        #region Parameter DirectInternetAccess
        /// <summary>
        /// <para>
        /// <para>Sets whether SageMaker provides internet access to the notebook instance. If you set
        /// this to <c>Disabled</c> this notebook instance is able to access resources only in
        /// your VPC, and is not be able to connect to SageMaker training and endpoint services
        /// unless you configure a NAT Gateway in your VPC.</para><para>For more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/appendix-additional-considerations.html#appendix-notebook-and-internet-access">Notebook
        /// Instances Are Internet-Enabled by Default</a>. You can set the value of this parameter
        /// to <c>Disabled</c> only if you set a value for the <c>SubnetId</c> parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.DirectInternetAccess")]
        public Amazon.SageMaker.DirectInternetAccess DirectInternetAccess { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>The type of ML compute instance to launch for the notebook instance.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SageMaker.InstanceType")]
        public Amazon.SageMaker.InstanceType InstanceType { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a Amazon Web Services Key Management Service key
        /// that SageMaker uses to encrypt data on the storage volume attached to your notebook
        /// instance. The KMS key you provide must be enabled. For information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/enabling-keys.html">Enabling
        /// and Disabling Keys</a> in the <i>Amazon Web Services Key Management Service Developer
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
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
        
        #region Parameter InstanceMetadataServiceConfiguration_MinimumInstanceMetadataServiceVersion
        /// <summary>
        /// <para>
        /// <para>Indicates the minimum IMDS version that the notebook instance supports. When passed
        /// as part of <c>CreateNotebookInstance</c>, if no value is selected, then it defaults
        /// to IMDSv1. This means that both IMDSv1 and IMDSv2 are supported. If passed as part
        /// of <c>UpdateNotebookInstance</c>, there is no default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceMetadataServiceConfiguration_MinimumInstanceMetadataServiceVersion { get; set; }
        #endregion
        
        #region Parameter NotebookInstanceName
        /// <summary>
        /// <para>
        /// <para>The name of the new notebook instance.</para>
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
        
        #region Parameter PlatformIdentifier
        /// <summary>
        /// <para>
        /// <para>The platform identifier of the notebook instance runtime environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PlatformIdentifier { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para> When you send any requests to Amazon Web Services resources from the notebook instance,
        /// SageMaker assumes this role to perform tasks on your behalf. You must grant this role
        /// necessary permissions so SageMaker can perform these tasks. The policy must allow
        /// the SageMaker service principal (sagemaker.amazonaws.com) permissions to assume this
        /// role. For more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/sagemaker-roles.html">SageMaker
        /// Roles</a>. </para><note><para>To be able to pass this role to SageMaker, the caller of this API must have the <c>iam:PassRole</c>
        /// permission.</para></note>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter RootAccess
        /// <summary>
        /// <para>
        /// <para>Whether root access is enabled or disabled for users of the notebook instance. The
        /// default value is <c>Enabled</c>.</para><note><para>Lifecycle configurations need root access to be able to set up a notebook instance.
        /// Because of this, lifecycle configurations associated with a notebook instance always
        /// run with root access even if you disable root access for users.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.RootAccess")]
        public Amazon.SageMaker.RootAccess RootAccess { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The VPC security group IDs, in the form sg-xxxxxxxx. The security groups must be for
        /// the same VPC as specified in the subnet. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>The ID of the subnet in a VPC to which you would like to have a connectivity from
        /// your ML compute instance. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of key-value pairs. You can use tags to categorize your Amazon Web Services
        /// resources in different ways, for example, by purpose, owner, or environment. For more
        /// information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web Services Resources</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter VolumeSizeInGB
        /// <summary>
        /// <para>
        /// <para>The size, in GB, of the ML storage volume to attach to the notebook instance. The
        /// default value is 5 GB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? VolumeSizeInGB { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NotebookInstanceArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateNotebookInstanceResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateNotebookInstanceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NotebookInstanceArn";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NotebookInstanceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMNotebookInstance (CreateNotebookInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateNotebookInstanceResponse, NewSMNotebookInstanceCmdlet>(Select) ??
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
            context.DirectInternetAccess = this.DirectInternetAccess;
            context.InstanceMetadataServiceConfiguration_MinimumInstanceMetadataServiceVersion = this.InstanceMetadataServiceConfiguration_MinimumInstanceMetadataServiceVersion;
            context.InstanceType = this.InstanceType;
            #if MODULAR
            if (this.InstanceType == null && ParameterWasBound(nameof(this.InstanceType)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KmsKeyId = this.KmsKeyId;
            context.LifecycleConfigName = this.LifecycleConfigName;
            context.NotebookInstanceName = this.NotebookInstanceName;
            #if MODULAR
            if (this.NotebookInstanceName == null && ParameterWasBound(nameof(this.NotebookInstanceName)))
            {
                WriteWarning("You are passing $null as a value for parameter NotebookInstanceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PlatformIdentifier = this.PlatformIdentifier;
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RootAccess = this.RootAccess;
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupId = new List<System.String>(this.SecurityGroupId);
            }
            context.SubnetId = this.SubnetId;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
            }
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
            var request = new Amazon.SageMaker.Model.CreateNotebookInstanceRequest();
            
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
            if (cmdletContext.DirectInternetAccess != null)
            {
                request.DirectInternetAccess = cmdletContext.DirectInternetAccess;
            }
            
             // populate InstanceMetadataServiceConfiguration
            var requestInstanceMetadataServiceConfigurationIsNull = true;
            request.InstanceMetadataServiceConfiguration = new Amazon.SageMaker.Model.InstanceMetadataServiceConfiguration();
            System.String requestInstanceMetadataServiceConfiguration_instanceMetadataServiceConfiguration_MinimumInstanceMetadataServiceVersion = null;
            if (cmdletContext.InstanceMetadataServiceConfiguration_MinimumInstanceMetadataServiceVersion != null)
            {
                requestInstanceMetadataServiceConfiguration_instanceMetadataServiceConfiguration_MinimumInstanceMetadataServiceVersion = cmdletContext.InstanceMetadataServiceConfiguration_MinimumInstanceMetadataServiceVersion;
            }
            if (requestInstanceMetadataServiceConfiguration_instanceMetadataServiceConfiguration_MinimumInstanceMetadataServiceVersion != null)
            {
                request.InstanceMetadataServiceConfiguration.MinimumInstanceMetadataServiceVersion = requestInstanceMetadataServiceConfiguration_instanceMetadataServiceConfiguration_MinimumInstanceMetadataServiceVersion;
                requestInstanceMetadataServiceConfigurationIsNull = false;
            }
             // determine if request.InstanceMetadataServiceConfiguration should be set to null
            if (requestInstanceMetadataServiceConfigurationIsNull)
            {
                request.InstanceMetadataServiceConfiguration = null;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceType = cmdletContext.InstanceType;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.LifecycleConfigName != null)
            {
                request.LifecycleConfigName = cmdletContext.LifecycleConfigName;
            }
            if (cmdletContext.NotebookInstanceName != null)
            {
                request.NotebookInstanceName = cmdletContext.NotebookInstanceName;
            }
            if (cmdletContext.PlatformIdentifier != null)
            {
                request.PlatformIdentifier = cmdletContext.PlatformIdentifier;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.RootAccess != null)
            {
                request.RootAccess = cmdletContext.RootAccess;
            }
            if (cmdletContext.SecurityGroupId != null)
            {
                request.SecurityGroupIds = cmdletContext.SecurityGroupId;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetId = cmdletContext.SubnetId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.SageMaker.Model.CreateNotebookInstanceResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateNotebookInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateNotebookInstance");
            try
            {
                #if DESKTOP
                return client.CreateNotebookInstance(request);
                #elif CORECLR
                return client.CreateNotebookInstanceAsync(request).GetAwaiter().GetResult();
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
            public Amazon.SageMaker.DirectInternetAccess DirectInternetAccess { get; set; }
            public System.String InstanceMetadataServiceConfiguration_MinimumInstanceMetadataServiceVersion { get; set; }
            public Amazon.SageMaker.InstanceType InstanceType { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String LifecycleConfigName { get; set; }
            public System.String NotebookInstanceName { get; set; }
            public System.String PlatformIdentifier { get; set; }
            public System.String RoleArn { get; set; }
            public Amazon.SageMaker.RootAccess RootAccess { get; set; }
            public List<System.String> SecurityGroupId { get; set; }
            public System.String SubnetId { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Int32? VolumeSizeInGB { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateNotebookInstanceResponse, NewSMNotebookInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NotebookInstanceArn;
        }
        
    }
}
