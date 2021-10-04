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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Describes the customizations associated with the provided Amazon Web Services account
    /// and Amazon Amazon QuickSight namespace in an Amazon Web Services Region. The Amazon
    /// QuickSight console evaluates which customizations to apply by running this API operation
    /// with the <code>Resolved</code> flag included. 
    /// 
    ///  
    /// <para>
    /// To determine what customizations display when you run this command, it can help to
    /// visualize the relationship of the entities involved. 
    /// </para><ul><li><para><code>Amazon Web Services account</code> - The Amazon Web Services account exists
    /// at the top of the hierarchy. It has the potential to use all of the Amazon Web Services
    /// Regions and AWS Services. When you subscribe to Amazon QuickSight, you choose one
    /// Amazon Web Services Region to use as your home Region. That's where your free SPICE
    /// capacity is located. You can use Amazon QuickSight in any supported Amazon Web Services
    /// Region. 
    /// </para></li><li><para><code>Amazon Web Services Region</code> - In each Amazon Web Services Region where
    /// you sign in to Amazon QuickSight at least once, Amazon QuickSight acts as a separate
    /// instance of the same service. If you have a user directory, it resides in us-east-1,
    /// which is the US East (N. Virginia). Generally speaking, these users have access to
    /// Amazon QuickSight in any Amazon Web Services Region, unless they are constrained to
    /// a namespace. 
    /// </para><para>
    /// To run the command in a different Amazon Web Services Region, you change your Region
    /// settings. If you're using the AWS CLI, you can use one of the following options:
    /// </para><ul><li><para>
    /// Use <a href="https://docs.aws.amazon.com/cli/latest/userguide/cli-configure-options.html">command
    /// line options</a>. 
    /// </para></li><li><para>
    /// Use <a href="https://docs.aws.amazon.com/cli/latest/userguide/cli-configure-profiles.html">named
    /// profiles</a>. 
    /// </para></li><li><para>
    /// Run <code>aws configure</code> to change your default Amazon Web Services Region.
    /// Use Enter to key the same settings for your keys. For more information, see <a href="https://docs.aws.amazon.com/cli/latest/userguide/cli-chap-configure.html">Configuring
    /// the AWS CLI</a>.
    /// </para></li></ul></li><li><para><code>Namespace</code> - A Amazon QuickSight namespace is a partition that contains
    /// users and assets (data sources, datasets, dashboards, and so on). To access assets
    /// that are in a specific namespace, users and groups must also be part of the same namespace.
    /// People who share a namespace are completely isolated from users and assets in other
    /// namespaces, even if they are in the same Amazon Web Services account and Amazon Web
    /// Services Region.
    /// </para></li><li><para><code>Applied customizations</code> - Within an Amazon Web Services Region, a set
    /// of Amazon QuickSight customizations can apply to an Amazon Web Services account or
    /// to a namespace. Settings that you apply to a namespace override settings that you
    /// apply to an Amazon Web Services account. All settings are isolated to a single Amazon
    /// Web Services Region. To apply them in other Amazon Web Services Regions, run the <code>CreateAccountCustomization</code>
    /// command in each Amazon Web Services Region where you want to apply the same customizations.
    /// 
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "QSAccountCustomization")]
    [OutputType("Amazon.QuickSight.Model.DescribeAccountCustomizationResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight DescribeAccountCustomization API operation.", Operation = new[] {"DescribeAccountCustomization"}, SelectReturnType = typeof(Amazon.QuickSight.Model.DescribeAccountCustomizationResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.DescribeAccountCustomizationResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.DescribeAccountCustomizationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetQSAccountCustomizationCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID for the Amazon Web Services account that you want to describe Amazon QuickSight
        /// customizations for.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The Amazon QuickSight namespace that you want to describe Amazon QuickSight customizations
        /// for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Namespace { get; set; }
        #endregion
        
        #region Parameter Resolved
        /// <summary>
        /// <para>
        /// <para>The <code>Resolved</code> flag works with the other parameters to determine which
        /// view of Amazon QuickSight customizations is returned. You can add this flag to your
        /// command to use the same view that Amazon QuickSight uses to identify which customizations
        /// to apply to the console. Omit this flag, or set it to <code>no-resolved</code>, to
        /// reveal customizations that are configured at different levels. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Resolved { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.DescribeAccountCustomizationResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.DescribeAccountCustomizationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AwsAccountId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AwsAccountId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AwsAccountId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.DescribeAccountCustomizationResponse, GetQSAccountCustomizationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AwsAccountId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Namespace = this.Namespace;
            context.Resolved = this.Resolved;
            
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
            var request = new Amazon.QuickSight.Model.DescribeAccountCustomizationRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.Namespace != null)
            {
                request.Namespace = cmdletContext.Namespace;
            }
            if (cmdletContext.Resolved != null)
            {
                request.Resolved = cmdletContext.Resolved.Value;
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
        
        private Amazon.QuickSight.Model.DescribeAccountCustomizationResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.DescribeAccountCustomizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "DescribeAccountCustomization");
            try
            {
                #if DESKTOP
                return client.DescribeAccountCustomization(request);
                #elif CORECLR
                return client.DescribeAccountCustomizationAsync(request).GetAwaiter().GetResult();
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
            public System.String AwsAccountId { get; set; }
            public System.String Namespace { get; set; }
            public System.Boolean? Resolved { get; set; }
            public System.Func<Amazon.QuickSight.Model.DescribeAccountCustomizationResponse, GetQSAccountCustomizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
